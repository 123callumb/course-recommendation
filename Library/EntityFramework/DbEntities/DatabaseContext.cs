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
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionAnswer> SessionAnswers { get; set; }

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

                entity.HasIndex(e => e.SectionId, "FK_Section_Answer");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AnswerID");

                entity.Property(e => e.Order)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SectionID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_Answer");
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

                entity.HasIndex(e => e.SectionId, "FK_Question_Section");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuestionID");

                entity.Property(e => e.Order).HasColumnType("int(11)");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SectionID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Section");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SectionID");

                entity.Property(e => e.Order)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.Property(e => e.SessionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SessionID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<SessionAnswer>(entity =>
            {
                entity.ToTable("session_answer");

                entity.HasIndex(e => e.SessionId, "FK_Session");

                entity.HasIndex(e => e.AnswerId, "FK_Session_Answer");

                entity.HasIndex(e => e.QuestionId, "FK_Session_Question");

                entity.HasIndex(e => e.SectionId, "FK_Session_Section");

                entity.Property(e => e.SessionAnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SessionAnswerID");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AnswerID");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuestionID");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SectionID");

                entity.Property(e => e.SessionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SessionID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.SessionAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SessionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Session_Question");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SessionAnswers)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Section");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionAnswers)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
