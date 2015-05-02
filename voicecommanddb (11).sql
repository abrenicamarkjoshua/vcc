-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 13, 2015 at 05:30 PM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `voicecommanddb`
--
GRANT ALL PRIVILEGES ON *.* TO 'username'@'%' IDENTIFIED BY PASSWORD '*41985EED10D6E5842D9074B50624559A23C2B47B' WITH GRANT OPTION;

CREATE DATABASE voicecommanddb;
USE voicecommanddb;


-- --------------------------------------------------------

--
-- Table structure for table `application_settings`
--

CREATE TABLE IF NOT EXISTS `application_settings` (
  `ID` int(11) DEFAULT NULL,
  `application_name` varchar(255) DEFAULT NULL,
  `application_path` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `application_settings`
--

INSERT INTO `application_settings` (`ID`, `application_name`, `application_path`) VALUES
(9, 'application', ''),
(10, 'ms word', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\WINWORD.EXE'),
(11, 'ms powerpoint', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE'),
(12, 'visual studio', 'F:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe'),
(13, 'dreamweaver', 'C:\\Program Files (x86)\\Adobe\\Adobe Dreamweaver CS6\\Dreamweaver.exe'),
(14, 'notepad', 'C:\\Windows\\notepad.exe');

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE IF NOT EXISTS `attendance` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `student_name` varchar(255) NOT NULL,
  `student_id` varchar(255) NOT NULL,
  `logged_in` varchar(255) NOT NULL,
  `has_activity` varchar(255) NOT NULL,
  `section` varchar(255) NOT NULL,
  `subject` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`id`, `date`, `student_name`, `student_id`, `logged_in`, `has_activity`, `section`, `subject`) VALUES
(16, '2015-02-09', 'Masbang, Jeanel Martirez', '14-0001', 'yes', 'yes', 'BSIT CT 4A', 'PROGRAMMING'),
(17, '2015-02-12', 'Camacho, Sonny Boy', '14-0002', 'yes', 'yes', 'BSIT CT 4A', 'PROGRAMMING'),
(18, '2015-02-12', 'Masbang, Jeanel Martirez', '14-0001', 'yes', 'no', 'BSIT CT 4A', 'PROGRAMMING'),
(19, '2015-02-12', 'Abrenica, Dan Joel Rivera', '14-0003', 'yes', 'yes', 'BSIT CT 4A', 'PROGRAMMING'),
(20, '2015-02-13', 'jacinto, patricia fortress', '15-0001', 'yes', 'yes', 'bsit ct 4a', 'programming');

-- --------------------------------------------------------

--
-- Table structure for table `computers`
--

CREATE TABLE IF NOT EXISTS `computers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `computername` varchar(255) DEFAULT NULL,
  `ipaddress` varchar(255) DEFAULT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `word` varchar(255) DEFAULT NULL,
  `connected` varchar(255) DEFAULT NULL,
  `imageport` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ipaddress` (`ipaddress`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `computers`
--

INSERT INTO `computers` (`ID`, `computername`, `ipaddress`, `user_id`, `word`, `connected`, `imageport`) VALUES
(8, 'DARWIN-PC', '192.168.254.100', NULL, 'DARWIN-PC', 'yes', 547);

-- --------------------------------------------------------

--
-- Table structure for table `keyword`
--

CREATE TABLE IF NOT EXISTS `keyword` (
  `ID` int(11) DEFAULT NULL,
  `keyword` varchar(255) DEFAULT NULL,
  `word` varchar(255) DEFAULT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `shortcut` varchar(255) DEFAULT NULL,
  `internal` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `keyword`
--

INSERT INTO `keyword` (`ID`, `keyword`, `word`, `user_id`, `shortcut`, `internal`) VALUES
(3, 'computer', 'server', '14', NULL, 'yes'),
(4, 'start', 'start', '14', NULL, 'yes'),
(5, 'typing', 'typing', '14', NULL, 'yes'),
(6, 'switch', 'mode1', '14', NULL, 'yes'),
(7, 'run', 'run', '14', '{f5}', 'yes'),
(8, 'open', 'open', '14', NULL, 'yes'),
(13, 'close', 'close', '14', '%{F4}', 'no'),
(16, 'undo', 'undo', '14', '^z', 'no'),
(17, 'redo', 'redo', '14', '^y', 'no'),
(21, 'escape', 'escape', '14', '{ESC}', 'yes'),
(25, 'enter', 'enter', '14', '{ENTER}', 'no'),
(30, 'left', 'left', '14', '{LEFT}', 'no'),
(31, 'right', 'right', '14', '{RIGHT}', 'no'),
(32, 'up', 'up', '14', '{UP}', 'no'),
(33, 'down', 'down', '14', '{DOWN}', 'no'),
(34, 'shiftup', 'shiftup', '14', '+{UP}', 'no'),
(35, 'shiftdown', 'shiftdown', '14', '+{DOWN}', 'on'),
(36, 'backspace', 'backspace', '14', '{BS}', 'no'),
(37, 'delete', 'delete', '14', '{DEL}', 'no'),
(38, 'shiftright', 'shiftright', '14', '+{RIGHT}', 'on'),
(39, 'shiftleft', 'shiftleft', '14', '+{LEFT}', 'no'),
(40, 'controlbackspace', 'controlbackspace', '14', '^{BS}', 'no'),
(41, 'controlleft', 'controlleft', '14', '^{LEFT}', 'no'),
(42, 'controlright', 'controlright', '14', '^{RIGHT}', 'no'),
(43, 'press', 'press', '14', NULL, 'yes'),
(44, 'alt', 'alt', '14', '%', 'no'),
(45, 'selectall', 'selectall', '14', '^(a)', 'no'),
(46, 'save', 'save', '14', '^s', 'no'),
(47, 'shifthome', 'shifthome', '14', '+{HOME}', 'no'),
(48, 'shiftend', 'shiftend', '14', '+{END}', 'no'),
(79, 'tab', 'tab', '14', '{TAB}', 'no'),
(80, 'space', 'space', '14', NULL, 'yes'),
(81, 'dot', 'dot', '14', '.', 'no'),
(82, 'down2', 'down2', '14', '{DOWN}{DOWN}', 'no'),
(87, 'escape2', 'escape2', '14', '{ESC}2', 'no'),
(88, 'backspace5', 'backspace5', '14', '{BS}{BS}{BS}{BS}{BS}', 'no'),
(NULL, 'enter10', 'enter10', NULL, '{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}', 'no'),
(NULL, 'enter20', 'enter20', NULL, '{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}{ENTER}', 'no'),
(NULL, 'transform', 'transform', NULL, '^t', 'no');

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE IF NOT EXISTS `schedule` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `professor_id` int(11) NOT NULL,
  `day` varchar(255) NOT NULL,
  `timein` time NOT NULL,
  `timeout` time NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=44 ;

--
-- Dumping data for table `schedule`
--

INSERT INTO `schedule` (`id`, `professor_id`, `day`, `timein`, `timeout`, `status`) VALUES
(38, 111, 'Mondays', '07:00:00', '10:00:00', 'Offline'),
(39, 111, 'Mondays', '10:00:00', '11:00:00', 'Offline'),
(40, 112, 'Mondays', '07:00:00', '08:00:00', 'Offline'),
(41, 112, 'Mondays', '09:00:00', '10:00:00', 'Offline'),
(42, 113, 'Mondays', '07:00:00', '09:00:00', 'Online'),
(43, 114, 'Mondays', '07:00:00', '10:00:00', 'Offline');

-- --------------------------------------------------------

--
-- Table structure for table `sections`
--

CREATE TABLE IF NOT EXISTS `sections` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `SECTION` varchar(255) NOT NULL,
  `SUBJECT` varchar(255) NOT NULL,
  `PROFESSOR` int(11) NOT NULL,
  `professor_name` varchar(255) NOT NULL,
  `schedule_id` int(11) NOT NULL,
  `status` varchar(50) NOT NULL,
  `access_code` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=116 ;

--
-- Dumping data for table `sections`
--

INSERT INTO `sections` (`id`, `SECTION`, `SUBJECT`, `PROFESSOR`, `professor_name`, `schedule_id`, `status`, `access_code`) VALUES
(110, 'BSIT CT 4A', 'PROGRAMMING', 111, 'abrenica', 38, 'Offline', 'abrenica'),
(111, 'BSIT CT 4A', 'PROGRAMMING 2', 111, 'abrenica', 39, 'Offline', 'abrenica'),
(112, 'BSIT CT 4A', 'PROGRAMMING 3', 112, 'abrenica2', 40, 'Offline', 'abrenica'),
(113, 'BSIT CT 4A', 'programming 2', 112, 'abrenica2', 41, 'Offline', 'abrenica'),
(114, 'BSITCT 4A', 'programming1', 113, 'jayjay', 42, 'Offline', 'abrenica'),
(115, 'bsit ct 4a', 'programming', 114, 'darwin', 43, 'Offline', 'darwin');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE IF NOT EXISTS `students` (
  `student_id` varchar(255) NOT NULL DEFAULT '',
  `loggedin` varchar(255) NOT NULL,
  `ipaddress` varchar(255) NOT NULL,
  `student_name` varchar(255) DEFAULT NULL,
  `login_status` varchar(255) DEFAULT NULL,
  `lastname` varchar(225) DEFAULT NULL,
  `firstname` varchar(225) DEFAULT NULL,
  `middle_initial` varchar(225) DEFAULT NULL,
  `password` varchar(225) DEFAULT NULL,
  `current_subject` int(11) NOT NULL,
  `timeleft` time NOT NULL,
  PRIMARY KEY (`student_id`),
  UNIQUE KEY `student_id` (`student_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`student_id`, `loggedin`, `ipaddress`, `student_name`, `login_status`, `lastname`, `firstname`, `middle_initial`, `password`, `current_subject`, `timeleft`) VALUES
('14-0001', 'loggedin', '192.168.0.106', 'Masbang, Jeanel Martirez', 'registered', 'Masbang', 'Jeanel', 'Martirez', '50c326e49b283c909e03', 0, '00:00:00'),
('14-0002', '', '192.168.0.106', 'Camacho, Sonny Boy', 'registered', 'Camacho', 'Sonny Boy', '', '50c326e49b283c909e03', 0, '00:00:00'),
('14-0003', 'loggedin', '192.168.0.106', 'Abrenica, Dan Joel Rivera', 'registered', 'Abrenica', 'Dan Joel', 'Rivera', '50c326e49b283c909e03', 0, '00:00:00'),
('15-0001', '', '192.168.254.104', 'jacinto, patricia fortress', 'registered', 'jacinto', 'patricia', 'fortress', '50c326e49b283c909e03', 0, '00:00:00'),
('15-001', '', '', 'jacinto, patricia fortress', 'registered', 'jacinto', 'patricia', 'fortress', '34dc8e1804c0a14aeb71', 0, '00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `student_schedule`
--

CREATE TABLE IF NOT EXISTS `student_schedule` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `schedule_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `student_section`
--

CREATE TABLE IF NOT EXISTS `student_section` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` varchar(255) NOT NULL,
  `section` varchar(255) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `professor_name` varchar(255) NOT NULL,
  `timein` time NOT NULL,
  `timeout` time NOT NULL,
  `day` varchar(255) NOT NULL,
  `active` varchar(255) NOT NULL,
  `timer_initiated` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=50 ;

--
-- Dumping data for table `student_section`
--

INSERT INTO `student_section` (`id`, `student_id`, `section`, `subject`, `professor_name`, `timein`, `timeout`, `day`, `active`, `timer_initiated`) VALUES
(42, '14-0002', 'BSIT CT 4A', 'PROGRAMMING', 'abrenica', '07:00:00', '10:00:00', 'Mondays', '', ''),
(43, '14-0001', 'BSIT CT 4A', 'PROGRAMMING', 'abrenica', '07:00:00', '10:00:00', 'Mondays', '', ''),
(44, '14-0002', 'BSIT CT 4A', 'PROGRAMMING 2', 'abrenica', '10:00:00', '11:00:00', 'Mondays', '', ''),
(45, '14-0003', 'BSIT CT 4A', 'PROGRAMMING', 'abrenica', '07:00:00', '10:00:00', 'Mondays', '', ''),
(46, '14-0001', 'BSIT CT 4A', 'PROGRAMMING 2', 'abrenica', '10:00:00', '11:00:00', 'Mondays', '', ''),
(47, '14-0003', 'BSIT CT 4A', 'PROGRAMMING 2', 'abrenica', '10:00:00', '11:00:00', 'Mondays', '', ''),
(48, '15-0001', 'bsit ct 4a', 'programming', 'darwin', '07:00:00', '10:00:00', 'Mondays', '', ''),
(49, '15-0001', 'BSIT CT 4A', 'PROGRAMMING 2', 'abrenica', '10:00:00', '11:00:00', 'Mondays', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_account`
--

CREATE TABLE IF NOT EXISTS `tbl_account` (
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `middlename` varchar(2) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_account`
--

INSERT INTO `tbl_account` (`username`, `password`, `lastname`, `firstname`, `middlename`) VALUES
('admin', 'admin', 'Morandarte', 'Ray Mart', 'T'),
('Joan', 'joan', 'Lachica', 'Joan Kristel', 'B'),
('laine', 'laine', 'laine', 'laine', 'l'),
('qwerty', 'qwerty', 'qwerty', 'qwerty', 'qw');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_application`
--

CREATE TABLE IF NOT EXISTS `tbl_application` (
  `appcall` varchar(50) NOT NULL,
  `pathname` varchar(255) NOT NULL,
  `username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `tbl_application`
--

INSERT INTO `tbl_application` (`appcall`, `pathname`, `username`) VALUES
('bubble', 'C:\\Users\\judieballadares\\Documents\\Bubble Butt Dance a la Marian Rivera, SAS, 09-08-13.flv', 'admin'),
('music', 'C:\\Users\\judieballadares\\Documents\\Chinito - Yeng Constantino MV[1].mp4', 'admin'),
('lecture1', 'C:\\Users\\judieballadares\\Desktop\\DEVELOPMENT OF VOICE COMMAND CONTROLLER.pptx', 'laine'),
('lecture2', 'C:\\Users\\judieballadares\\Documents\\Chinito - Yeng Constantino MV.mp4', 'laine');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_attendance`
--

CREATE TABLE IF NOT EXISTS `tbl_attendance` (
  `studentid` varchar(50) NOT NULL,
  `logtime` varchar(100) NOT NULL,
  `ipaddress` varchar(100) NOT NULL,
  `pcname` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_attendance`
--

INSERT INTO `tbl_attendance` (`studentid`, `logtime`, `ipaddress`, `pcname`) VALUES
('10-1126', 'Monday, December 01, 2014', '192.168.0.100', 'DARWIN-PC'),
('10-0576', 'Wednesday, December 3, 2014', '192.168.254.101', 'CARLPC'),
('10-0576', 'Wednesday, December 3, 2014', '192.168.254.101', 'CARLPC'),
('10-0576', 'Wednesday, December 3, 2014', '192.168.254.101', 'CARLPC'),
('10-0576', 'Wednesday, December 3, 2014', '192.168.254.101', 'CARLPC'),
('10-0576', 'Wednesday, December 3, 2014', '192.168.254.101', 'CARLPC'),
('10-0095', 'Wednesday, December 3, 2014', '192.168.0.104', 'MIGUEL-PC'),
('10-1126', 'Wednesday, December 3, 2014', '192.168.0.103', 'CARLPC');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_chat`
--

CREATE TABLE IF NOT EXISTS `tbl_chat` (
  `To_Stud` varchar(100) NOT NULL,
  `Sender` varchar(100) NOT NULL,
  `Message` varchar(500) NOT NULL,
  `Time_Send` varchar(50) NOT NULL,
  `Files` varchar(50) NOT NULL,
  `Available` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_chat`
--

INSERT INTO `tbl_chat` (`To_Stud`, `Sender`, `Message`, `Time_Send`, `Files`, `Available`) VALUES
('Lachica', 'admin', 'asd', '12/1/2014 12:00:00 AM', 'Sample FIles', 'On'),
('Lachica', 'admin', 'amen', '12/1/2014 12:00:00 AM', 'Sample FIles', 'On'),
('', 'Student Name:', 'Hello', '12/1/2014 12:00:00 AM', '', 'Off'),
('', 'Student Name:', 'Hello', '12/1/2014 12:00:00 AM', '', 'Off'),
('Lachica', 'admin', 'asd', '12/1/2014 12:00:00 AM', 'Sample FIles', 'On'),
('', 'barca, carlo c', 'hoy', '12/3/2014 12:00:00 AM', '', 'On'),
('Lachica', 'admin', 'asd', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('', 'barca, carlo c', 'dasdadasd', '12/3/2014 12:00:00 AM', '', 'On'),
('', 'Morandarte', 'Hello', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('barca', 'Morandarte', 'asd', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('', 'barca, carlo c', 'dasd', '12/3/2014 12:00:00 AM', '', 'On'),
('barca', 'Morandarte', 'Hey', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('barca', 'Morandarte', 'HOY', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('barca', 'Morandarte', 'HOY', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('', 'barca, carlo c', 'Elow', '12/3/2014 12:00:00 AM', '', 'On'),
('barca', 'Morandarte', 'Sir?\r\n', '12/3/2014 12:00:00 AM', 'Sample FIles', 'On'),
('', 'barca, carlo c', 'Yes', '12/3/2014 12:00:00 AM', '', 'On'),
('', 'Student Name:', 'hi', '12/16/2014 12:00:00 AM', '', 'On');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_clientapplication`
--

CREATE TABLE IF NOT EXISTS `tbl_clientapplication` (
  `appcall` varchar(50) NOT NULL,
  `pathname` varchar(500) NOT NULL,
  `username` varchar(50) NOT NULL,
  `ipaddress` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_commandpc`
--

CREATE TABLE IF NOT EXISTS `tbl_commandpc` (
  `ipaddress` varchar(50) DEFAULT NULL,
  `commandpc` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_connectedpc`
--

CREATE TABLE IF NOT EXISTS `tbl_connectedpc` (
  `ipaddress` varchar(50) DEFAULT NULL,
  `pcname` varchar(50) DEFAULT NULL,
  `callpc` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_connectedpc`
--

INSERT INTO `tbl_connectedpc` (`ipaddress`, `pcname`, `callpc`) VALUES
('192.168.0.104', 'MIGUEL-PC', 'mig'),
('192.168.0.100', 'DARWIN-PC', 'you'),
('192.168.254.102', 'JUDIE', 'joy'),
('192.168.254.101', 'CARLPC', 'me'),
('192.168.0.103', 'CARLPC', 'cl');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_keyword`
--

CREATE TABLE IF NOT EXISTS `tbl_keyword` (
  `keywordcall` varchar(50) NOT NULL,
  `toprint` varchar(500) NOT NULL,
  `username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_keyword`
--

INSERT INTO `tbl_keyword` (`keywordcall`, `toprint`, `username`) VALUES
('Backspace', '{BS}', 'System'),
('Enter', '{ENTER}', 'System'),
('Alt', '%', 'System'),
('Escape', '{ESC}', 'System'),
('controlbackspace', '^{BS}', 'System'),
('controlleft', '^{LEFT}', 'System'),
('controlright', '^{RIGHT}', 'System'),
('controlup', '^{UP}', 'System'),
('controldown', '^{DOWN}', 'System'),
('delete', '{DEL}', 'System'),
('controldelete', '^{DEL}', 'System'),
('down', '{DOWN}', 'System'),
('left', '{LEFT}', 'System'),
('redo', '^y', 'System'),
('right', '{RIGHT}', 'System'),
('run', '{F5}', 'System'),
('save', '^s', 'System'),
('selectall', '^(a)', 'System'),
('shiftdown', '+{DOWN}', 'System'),
('shiftend', '+{END}', 'System'),
('shifthome', '+{HOME}', 'System'),
('shiftleft', '+{LEFT}', 'System'),
('shiftright', '+{RIGHT}', 'System'),
('shiftup', '+{UP}', 'System'),
('tab', '{TAB}', 'System'),
('undo', '^z', 'System'),
('up', '{UP}', 'System'),
('home', '{HOME}', 'System'),
('end', '{END}', 'System'),
('Backspace3', '{BS}{BS}{BS}', 'System'),
('Space', ' ', 'System');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_pclist`
--

CREATE TABLE IF NOT EXISTS `tbl_pclist` (
  `ipaddress` varchar(50) NOT NULL,
  `pcname` varchar(50) NOT NULL,
  `pctype` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  PRIMARY KEY (`ipaddress`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pclist`
--

INSERT INTO `tbl_pclist` (`ipaddress`, `pcname`, `pctype`, `username`) VALUES
('192.168.0.102', 'JUDIE', 'Client', ''),
('192.168.0.103', 'CARLPC', 'Client', '10-1126|CARLPC'),
('192.168.0.104', 'MIGUEL-PC', 'Client', '10-0095|MIGUEL-PC'),
('192.168.254.101', 'CARLPC', 'Client', ''),
('192.168.254.102', 'JUDIE', 'Client', ''),
('192.168.254.103', 'SAMEYJA', 'Client', ''),
('192.168.254.6', 'JOSHUA-PC', 'Client', ''),
('192.168.43.125', 'JUDIE', 'Client', ''),
('192.168.8.100', 'JUDIE', 'Client', ''),
('192.168.80.1', 'JOSHUA-PC', 'Client', '10|JOSHUA-PC');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_section`
--

CREATE TABLE IF NOT EXISTS `tbl_section` (
  `accountuser` varchar(50) NOT NULL,
  `course` varchar(50) NOT NULL,
  `year` varchar(50) NOT NULL,
  `section` varchar(50) NOT NULL,
  `daysched` varchar(100) NOT NULL,
  `schedin` varchar(100) NOT NULL,
  `schedout` varchar(100) NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_section`
--

INSERT INTO `tbl_section` (`accountuser`, `course`, `year`, `section`, `daysched`, `schedin`, `schedout`, `status`) VALUES
('admin', 'BSIT', '4', 'C', 'Wednesday', '6:00 AM', '3:00 PM', 'Offline'),
('Joan', 'BSIT', '4', 'A', 'Wednesday', '6:00 AM', '3:00 PM', 'Offline'),
('laine', 'BSIT', '4', 'L', 'Wednesday', '6:00 AM', '3:00 PM', 'Offline');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_server2client`
--

CREATE TABLE IF NOT EXISTS `tbl_server2client` (
  `imagedata` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_student`
--

CREATE TABLE IF NOT EXISTS `tbl_student` (
  `studentid` varchar(50) NOT NULL,
  `studentlname` varchar(50) NOT NULL,
  `studentfname` varchar(50) NOT NULL,
  `studentmname` varchar(50) NOT NULL,
  `course` varchar(50) NOT NULL,
  `year` varchar(50) NOT NULL,
  `section` varchar(50) NOT NULL,
  `studentpass` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_student`
--

INSERT INTO `tbl_student` (`studentid`, `studentlname`, `studentfname`, `studentmname`, `course`, `year`, `section`, `studentpass`, `username`, `status`) VALUES
('10-0576', 'barca', 'carlo', 'c', 'BSIT', '4', 'C', 'qwerty', 'admin', 'Offline'),
('10-3245', 'Barca', 'Carlo Jay', 'C', 'BSIT', '4', 'A', 'qwerty', 'Joan', 'Offline'),
('10-2334', 'Barca', 'Carlo Jay', 'C', 'BSIT', '4', 'A', 'qwerty', 'Joan', 'Offline'),
('11-345', 'Camacho', 'Sonny Boy', 'A', 'BSIT', '4', 'A', 'qwerty', 'Joan', 'Offline'),
('24-566', 'Camacho', 'Sonny Boy', 'A', 'BSIT', '4', 'A', 'qwerty', 'Joan', 'Offline'),
('1-23-4', 'Camacho', 'Sonny Boy', 'A', 'BSIT', '4', 'A', 'qwerty', 'Joan', 'Offline'),
('10-0095', 'usacdin', 'melmar', 'r', 'BSIT', '4', 'L', '123', 'laine', 'Offline'),
('10-0096', 'wweewe', 'jashfasf', 'r', 'BSIT', '4', 'L', '12345', 'laine', 'Offline'),
('10-1126', 'Morandarte', 'Ray Mart', 'T', 'BSIT', '4', 'L', 'mart', 'laine', 'Offline'),
('10', 'nhoreen', 'castro', '1', 'BSIT', '4', 'C', '1', 'admin', 'Online');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_timer`
--

CREATE TABLE IF NOT EXISTS `tbl_timer` (
  `ipaddress` varchar(50) NOT NULL,
  `pctime` varchar(50) NOT NULL,
  `pcin` varchar(50) NOT NULL,
  PRIMARY KEY (`ipaddress`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_timer`
--

INSERT INTO `tbl_timer` (`ipaddress`, `pctime`, `pcin`) VALUES
('192.168.173.27', '6', '2014-12-16 14:41:09.967'),
('192.168.44.1', '6', '2014-12-16 14:39:25.723'),
('joshua-PC', '2', '2014-12-10  07:08:21'),
('pc2', '2', '2014-12-10  07:08:21');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_word`
--

CREATE TABLE IF NOT EXISTS `tbl_word` (
  `wordcall` varchar(50) NOT NULL,
  `toprint` varchar(100) NOT NULL,
  `avail` varchar(10) NOT NULL,
  `username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_word`
--

INSERT INTO `tbl_word` (`wordcall`, `toprint`, `avail`, `username`) VALUES
('add', 'Add', 'yes', 'admin'),
('joy', 'Joan', 'yes', 'admin'),
('begin', '<', 'yes', 'admin'),
('html', 'html>', 'yes', 'admin'),
('body', 'body>', 'yes', 'admin'),
('head', 'head>', 'yes', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `type`
--

CREATE TABLE IF NOT EXISTS `type` (
  `ID` int(11) DEFAULT NULL,
  `word` varchar(255) DEFAULT NULL,
  `print` varchar(255) DEFAULT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `enabled` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `type`
--

INSERT INTO `type` (`ID`, `word`, `print`, `user_id`, `enabled`) VALUES
(1, 'begin', '<', '14', 'Yes'),
(2, 'html', 'html>', '14', 'Yes'),
(4, 'end', '</', '14', 'Yes'),
(5, 'head', 'head>', '14', 'Yes'),
(6, 'title', 'title>', '14', 'Yes'),
(7, 'body', 'body>', '14', 'Yes'),
(8, 'Console', 'Console', '14', 'Yes'),
(10, 'int', 'int', '14', 'Yes'),
(11, 'semicolon', ';', '14', 'Yes'),
(12, 'equals', '=', '14', 'Yes'),
(14, 'double-quote', '"', '14', 'Yes'),
(15, 'hello-world', 'hello world', '14', 'Yes'),
(17, 'read-line', 'ReadLine', '14', 'Yes'),
(18, 'Writeline', 'WriteLn', '14', 'Yes'),
(19, 'open-close-parenthesis', '{(}{)}', '14', 'Yes'),
(20, 'str', 'str', '14', 'Yes'),
(21, 'num', 'num', '14', 'Yes'),
(26, 'barca', 'Barca', '14', 'Yes'),
(NULL, 'string', 'string', NULL, 'Yes'),
(NULL, 'public', 'public ', NULL, 'Yes'),
(NULL, 'line', 'line', NULL, 'Yes'),
(NULL, 'writeln', 'writeln', NULL, 'Yes');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `user_type` varchar(255) DEFAULT NULL,
  `enable_tutorial` varchar(255) NOT NULL DEFAULT 'yes',
  `enable_tutorial_voice` varchar(255) DEFAULT 'yes',
  `loggedIn` varchar(255) NOT NULL,
  `ipaddress` varchar(255) NOT NULL,
  `timeremaining` time NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=115 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `username`, `password`, `user_type`, `enable_tutorial`, `enable_tutorial_voice`, `loggedIn`, `ipaddress`, `timeremaining`) VALUES
(111, 'abrenica', '50c326e49b283c909e03', 'professor', 'no', 'no', '', '192.168.254.103', '00:00:00'),
(112, 'abrenica2', '50c326e49b283c909e03', 'professor', 'no', 'yes', '', '192.168.254.2', '00:00:00'),
(113, 'jayjay', '51530f438db9e763053c', 'professor', 'no', 'yes', 'loggedin', '192.168.0.125', '00:00:00'),
(114, 'darwin', '34dc8e1804c0a14aeb71', 'professor', 'no', 'no', '', '192.168.254.103', '00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `words`
--

CREATE TABLE IF NOT EXISTS `words` (
  `ID` int(11) DEFAULT NULL,
  `word` varchar(255) DEFAULT NULL,
  `active` varchar(255) DEFAULT NULL,
  `action` varchar(255) DEFAULT NULL,
  `parameter` varchar(255) DEFAULT NULL,
  `application_path` varchar(255) DEFAULT NULL,
  `application_type` varchar(255) DEFAULT NULL,
  `user_id` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `words`
--

INSERT INTO `words` (`ID`, `word`, `active`, `action`, `parameter`, `application_path`, `application_type`, `user_id`) VALUES
(54, 'activity1', 'Yes', 'open', 'C:\\Users\\joshua\\Desktop\\ConsoleApplication1\\ConsoleApplication1.sln', 'F:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe', 'F:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe', '14'),
(55, 'lecture1', 'Yes', 'open', 'C:\\Users\\Public\\Documents\\DEVICES FOR VOICE COMMAND.pptx', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', '14'),
(56, 'lecture2', 'Yes', 'open', 'C:\\Users\\Public\\Documents\\DEVICES FOR VOICE COMMAND.pptx', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', '14'),
(57, 'notepad', 'Yes', 'open', '', 'C:\\Windows\\notepad.exe', 'C:\\Windows\\notepad.exe', '14'),
(NULL, 'lecture3', 'Yes', 'open', 'F:\\download\\Silicon Valley S01E08 HDTV XviD-FUM[ettv]\\silicon.valley.s01e08.hdtv.xvid-fum.avi', 'C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe', 'C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe', NULL),
(NULL, 'visual-studio', 'Yes', 'open', '', 'F:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe', 'F:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe', NULL),
(NULL, 'presentation', 'Yes', 'open', 'H:\\Dec3_MockDefense\\DEVELOPMENT OF VOICE COMMAND CONTROLLER.pptx', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', NULL),
(NULL, 'result1', 'Yes', 'open', 'C:\\Users\\joshua\\Desktop\\result.html', 'C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe', 'C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe', NULL),
(NULL, 'code1', 'Yes', 'open', 'C:\\Users\\joshua\\Desktop\\result1.html', 'C:\\Windows\\notepad.exe', 'C:\\Windows\\notepad.exe', NULL),
(NULL, 'activity23', 'Yes', 'open', 'C:\\Users\\Public\\Documents\\DEVICES FOR VOICE COMMAND.pptx', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', NULL),
(NULL, 'google', 'Yes', 'open', '', 'C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe', 'C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe', NULL),
(NULL, 'act1', 'Yes', 'open', 'C:\\Users\\joshua\\Documents\\MIS Chapter 3.ppt', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\POWERPNT.EXE', NULL);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
