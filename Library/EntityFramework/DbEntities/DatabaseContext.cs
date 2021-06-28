using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual DbSet<QuestionGroup> QuestionGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=course_recommendation", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AnswerID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CourseID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.HasIndex(e => e.GroupId, "FK_Question_Group");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuestionID");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GroupID");

                entity.Property(e => e.Order).HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Question_Group");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.ToTable("question_answer");

                entity.HasIndex(e => e.AnswerId, "FK_Answer");

                entity.HasIndex(e => e.QuestionId, "FK_Question");

                entity.Property(e => e.QuestionAnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuestionAnswerID");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AnswerID");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuestionID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question");
            });

            modelBuilder.Entity<QuestionGroup>(entity =>
            {
                entity.ToTable("question_group");

                entity.Property(e => e.QuestionGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuestionGroupID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
