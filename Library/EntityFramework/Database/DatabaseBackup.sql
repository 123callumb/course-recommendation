/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE IF NOT EXISTS `course_recommendation` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `course_recommendation`;

CREATE TABLE IF NOT EXISTS `answer` (
  `AnswerID` int(11) NOT NULL AUTO_INCREMENT,
  `SectionID` int(11) NOT NULL DEFAULT 1,
  `Text` varchar(2000) NOT NULL,
  `Order` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`AnswerID`),
  KEY `FK_Section_Answer` (`SectionID`),
  CONSTRAINT `FK_Section_Answer` FOREIGN KEY (`SectionID`) REFERENCES `section` (`SectionID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4;

DELETE FROM `answer`;
/*!40000 ALTER TABLE `answer` DISABLE KEYS */;
INSERT INTO `answer` (`AnswerID`, `SectionID`, `Text`, `Order`) VALUES
	(1, 1, 'Younger than 20 years old', 1),
	(2, 1, '20-29 years old', 2),
	(3, 1, '30 - 39 years old', 3),
	(4, 1, '40 - 49 years old', 4),
	(5, 1, '50 - 59 years old', 5),
	(6, 1, '60 or more years old', 6),
	(7, 2, 'Female', 1),
	(8, 2, 'Male', 2),
	(9, 2, 'Prefer not to say', 3),
	(10, 3, 'Yes I can do this', 1),
	(11, 3, 'Perhaps, I\'m not sure', 2),
	(12, 3, 'No I couldn\'t do this', 3),
	(13, 4, 'Yes I can do this', 1),
	(14, 4, 'Perhaps, I\'m not sure', 2),
	(15, 4, 'No I couldn\'t do this', 3),
	(16, 5, 'I have no idea what you\'re talking about', 1),
	(17, 5, 'No, I couldn\'t do this', 2),
	(18, 5, 'Yes, I could do this if I needed to', 3),
	(19, 6, 'I have no idea what you\'re talking about', 1),
	(20, 6, 'No, I couldn\'t do this', 2),
	(21, 6, 'Yes, I could do this if I needed to', 3),
	(22, 7, 'I have no idea what you\'re talking about', 1),
	(23, 7, 'No, I couldn\'t do this', 2),
	(24, 7, 'Yes, I could do this if I needed to', 3),
	(25, 8, 'I have no idea what you\'re talking about', 1),
	(26, 8, 'No, I couldn\'t do this', 2),
	(27, 8, 'Yes, I could do this if I needed to', 3),
	(28, 9, 'I have no idea what you\'re talking about', 1),
	(29, 9, 'No, I couldn\'t do this', 2),
	(30, 9, 'Yes, I could do this if I needed to', 3),
	(31, 10, 'I have no idea what you\'re talking about', 1),
	(32, 10, 'No, I couldn\'t do this', 2),
	(33, 10, 'Yes, I could do this if I needed to', 3),
	(34, 11, 'I have no idea what you\'re talking about', 1),
	(35, 11, 'No, I couldn\'t do this', 2),
	(36, 11, 'Yes, I could do this if I needed to', 3),
	(37, 12, 'I have no idea what you\'re talking about', 1),
	(38, 12, 'No, I couldn\'t do this', 2),
	(39, 12, 'Yes, I could do this if I needed to', 3),
	(40, 13, 'I have no idea what you\'re talking about', 1),
	(41, 13, 'No, I couldn\'t do this', 2),
	(42, 13, 'Yes, I could do this if I needed to', 3),
	(43, 14, 'I have no idea what you\'re talking about', 1),
	(44, 14, 'No, I couldn\'t do this', 2),
	(45, 14, 'Yes, I could do this if I needed to', 3),
	(46, 15, 'I have no idea what you\'re talking about', 1),
	(47, 15, 'No, I couldn\'t do this', 2),
	(48, 15, 'Yes, I could do this if I needed to', 3);
/*!40000 ALTER TABLE `answer` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `course` (
  `CourseID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(400) NOT NULL,
  `Description` varchar(2000) NOT NULL,
  PRIMARY KEY (`CourseID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

DELETE FROM `course`;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` (`CourseID`, `Name`, `Description`) VALUES
	(1, 'Transacting Digital Skills Course', 'This course includes the learning of skills required to register and apply for services, buy and sell goods and services, and administer and manage transactions online.');
/*!40000 ALTER TABLE `course` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `group` (
  `GroupID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  `Description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`GroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

DELETE FROM `group`;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` (`GroupID`, `Name`, `Description`) VALUES
	(1, 'Digital Skills Assessment', 'This form has been developed to identify the digital skills of Sheffield City Council staff. The information from this  questionnaire is completely confidential and will be used to inform us of the types of training programmes needed to ensure our staff can live confidently in an increasingly digital world.'),
	(2, 'A little about you...', 'This information is being collected to group similar people. This information is not used to identify you as an individual.'),
	(3, 'Digital Foundation Skills', NULL),
	(4, 'Managing Information', NULL),
	(5, 'Communicating', NULL),
	(6, 'Transacting', NULL),
	(7, 'Problem Solving', NULL),
	(8, 'Creating', NULL);
/*!40000 ALTER TABLE `group` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `question` (
  `QuestionID` int(11) NOT NULL AUTO_INCREMENT,
  `Text` varchar(2000) NOT NULL,
  `Order` int(11) DEFAULT NULL,
  `SectionID` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`QuestionID`),
  KEY `FK_Question_Section` (`SectionID`),
  CONSTRAINT `FK_Question_Section` FOREIGN KEY (`SectionID`) REFERENCES `section` (`SectionID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

DELETE FROM `question`;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
INSERT INTO `question` (`QuestionID`, `Text`, `Order`, `SectionID`) VALUES
	(3, 'Book holidays, flights, hotels', 1, 3),
	(4, 'Book a doctor or hospital appointment', 2, 3),
	(5, 'Pay taxes (Council tax, Road tax etc)', 3, 3),
	(6, 'Set up and use an online shoppping account', 4, 3),
	(7, 'Complete application forms', 5, 3),
	(8, 'Buy and install software (programmes, apps etc)', 6, 3),
	(9, 'Request and view annual leave or expenses', 1, 4),
	(10, 'Access salary, expenses and payslip information', 2, 4);
/*!40000 ALTER TABLE `question` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `section` (
  `SectionID` int(11) NOT NULL AUTO_INCREMENT,
  `Text` varchar(2000) NOT NULL,
  `Order` int(11) NOT NULL DEFAULT 1,
  `GroupID` int(11) NOT NULL,
  PRIMARY KEY (`SectionID`),
  KEY `FK_Section_Group` (`GroupID`),
  CONSTRAINT `FK_Section_Group` FOREIGN KEY (`GroupID`) REFERENCES `group` (`GroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;

DELETE FROM `section`;
/*!40000 ALTER TABLE `section` DISABLE KEYS */;
INSERT INTO `section` (`SectionID`, `Text`, `Order`, `GroupID`) VALUES
	(1, 'How old are you?', 1, 2),
	(2, 'Gender', 2, 2),
	(3, 'At home I can use the internet to...', 3, 3),
	(4, 'At work I can use the internet to...', 4, 3),
	(5, 'Can you use a search engine to look for information online?', 5, 4),
	(6, 'Can you download/save a photo you found online', 6, 4),
	(7, 'Can you find a website you have visited before?', 7, 4),
	(8, 'Can you send a personal message to another person using email or an online message service?', 8, 5),
	(9, 'Can you carefully make comments and share information online?', 9, 5),
	(10, 'Can you buy items or services from a website?', 10, 6),
	(11, 'Can you buy and install apps on a device?', 11, 6),
	(12, 'Can you solve a problem you have with a device or digital service using online help?', 12, 7),
	(13, 'Can you verify sources of information you have found online?', 13, 7),
	(14, 'Can you complete online application forms which include personal details?', 14, 8),
	(15, 'Can you create something new from existing online images, music or video?', 15, 8);
/*!40000 ALTER TABLE `section` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `session` (
  `SessionID` int(11) NOT NULL AUTO_INCREMENT,
  `DateCreated` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`SessionID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

DELETE FROM `session`;
/*!40000 ALTER TABLE `session` DISABLE KEYS */;
INSERT INTO `session` (`SessionID`, `DateCreated`) VALUES
	(1, '2021-07-04 21:12:52'),
	(2, '2021-07-04 21:37:38'),
	(3, '2021-07-04 21:57:14'),
	(4, '2021-07-05 18:36:35');
/*!40000 ALTER TABLE `session` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `session_answer` (
  `SessionAnswerID` int(11) NOT NULL AUTO_INCREMENT,
  `SessionID` int(11) NOT NULL,
  `SectionID` int(11) NOT NULL,
  `AnswerID` int(11) NOT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  PRIMARY KEY (`SessionAnswerID`),
  UNIQUE KEY `SessionID_SectionID_QuestionID` (`SessionID`,`SectionID`,`QuestionID`),
  KEY `FK_Session_Section` (`SectionID`),
  KEY `FK_Session_Answer` (`AnswerID`),
  KEY `FK_Session_Question` (`QuestionID`),
  CONSTRAINT `FK_Session` FOREIGN KEY (`SessionID`) REFERENCES `session` (`SessionID`),
  CONSTRAINT `FK_Session_Answer` FOREIGN KEY (`AnswerID`) REFERENCES `answer` (`AnswerID`),
  CONSTRAINT `FK_Session_Question` FOREIGN KEY (`QuestionID`) REFERENCES `question` (`QuestionID`),
  CONSTRAINT `FK_Session_Section` FOREIGN KEY (`SectionID`) REFERENCES `section` (`SectionID`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4;

DELETE FROM `session_answer`;
/*!40000 ALTER TABLE `session_answer` DISABLE KEYS */;
INSERT INTO `session_answer` (`SessionAnswerID`, `SessionID`, `SectionID`, `AnswerID`, `QuestionID`) VALUES
	(1, 1, 1, 2, NULL),
	(2, 1, 2, 8, NULL),
	(3, 1, 3, 10, 3),
	(4, 1, 3, 10, 4),
	(5, 1, 3, 10, 5),
	(6, 1, 3, 10, 6),
	(7, 1, 3, 10, 7),
	(8, 1, 3, 10, 8),
	(9, 1, 4, 13, 9),
	(10, 1, 4, 13, 10),
	(11, 2, 1, 2, NULL),
	(12, 2, 2, 8, NULL),
	(13, 2, 3, 10, 4),
	(14, 2, 3, 10, 3),
	(15, 2, 3, 10, 5),
	(16, 2, 3, 10, 6),
	(17, 2, 3, 10, 7),
	(18, 2, 3, 10, 8),
	(19, 2, 4, 13, 9),
	(20, 2, 4, 13, 10),
	(21, 3, 1, 2, NULL),
	(22, 3, 2, 8, NULL),
	(23, 3, 3, 10, 3),
	(24, 3, 3, 10, 4),
	(25, 3, 3, 10, 5),
	(26, 3, 3, 10, 6),
	(27, 3, 3, 10, 7),
	(28, 3, 3, 10, 8),
	(29, 3, 4, 13, 9),
	(30, 3, 4, 13, 10),
	(31, 4, 1, 2, NULL),
	(32, 4, 13, 42, NULL),
	(33, 4, 12, 39, NULL),
	(34, 4, 11, 36, NULL),
	(35, 4, 10, 33, NULL),
	(36, 4, 9, 30, NULL),
	(37, 4, 8, 27, NULL),
	(38, 4, 7, 24, NULL),
	(39, 4, 6, 21, NULL),
	(40, 4, 14, 45, NULL),
	(41, 4, 5, 18, NULL),
	(42, 4, 4, 13, 9),
	(43, 4, 3, 10, 8),
	(44, 4, 3, 10, 5),
	(45, 4, 3, 10, 7),
	(46, 4, 3, 10, 6),
	(47, 4, 3, 10, 4),
	(48, 4, 3, 10, 3),
	(49, 4, 2, 8, NULL),
	(50, 4, 4, 13, 10),
	(51, 4, 15, 48, NULL);
/*!40000 ALTER TABLE `session_answer` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
