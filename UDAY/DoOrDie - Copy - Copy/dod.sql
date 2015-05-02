-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 24, 2015 at 04:28 AM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dod`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_account`
--

CREATE TABLE IF NOT EXISTS `tbl_account` (
  `accountuser` varchar(20) NOT NULL DEFAULT '',
  `accountpass` varchar(255) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `middlename` varchar(100) NOT NULL,
  `isTutorial` varchar(5) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `wordtype` varchar(255) NOT NULL,
  PRIMARY KEY (`accountuser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_account`
--

INSERT INTO `tbl_account` (`accountuser`, `accountpass`, `lastname`, `firstname`, `middlename`, `isTutorial`, `gender`, `wordtype`) VALUES
('admin', '1234', 'Morandarte', 'Ray Mart', '', 'No', 'Male', 'HTML'),
('grace', '1234', 'Yap', 'Yap', 'Yap', 'No', 'Female', 'HTML'),
('Jay', 'Jam28', 'Guiang', 'Jay', 'Lascano', 'No', 'Male', 'HTML'),
('jayjay', 'jay', 'Guiang', 'Jayjay', '', 'No', 'Male', 'HTML'),
('jeanel', 'jeanel', 'masbang', 'jeanel', 'martirez', 'No', 'Female', 'HTML'),
('jeljosh', 'jel08mja', 'reyes', 'jel', 'quintos', 'No', 'Female', 'HTML'),
('jelly', 'june', 'elune', 'emiko', 'sato', 'No', 'Female', 'HTML'),
('joan', 'joan', 'lachica', 'kristel', 'bacay', 'No', 'Female', 'HTML'),
('joanjoan', 'joan', 'Lachica', 'Joan Kristel', 'Baboy', 'No', 'Female', 'HTML'),
('joanmart', 'joan', 'Lachica', 'Joan Kristel', 'Bacay', 'No', 'Female', 'HTML'),
('joanmart5711', 'joanmart', 'Morandarte', 'Joan Kristel', 'Lachica', 'No', 'Female', 'HTML'),
('Joy', '0000', 'Yumang', ' Joy', 'Doctor', 'No', 'Female', 'HTML'),
('rheyan', '1234', 'Lescano', 'Rhey-An', '', 'No', 'Male', 'HTML'),
('test', 'test', 'test', 'test', 'test', 'No', 'Male', 'HTML'),
('username', 'password', 'Morandarte', 'Ray Mart', 'Tatad', 'No', 'Male', 'HTML');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_application`
--

CREATE TABLE IF NOT EXISTS `tbl_application` (
  `wordcall` varchar(100) NOT NULL,
  `defpath` varchar(500) DEFAULT NULL,
  `conpath` varchar(500) DEFAULT NULL,
  `accountuser` varchar(100) NOT NULL,
  `apptype` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_application`
--

INSERT INTO `tbl_application` (`wordcall`, `defpath`, `conpath`, `accountuser`, `apptype`) VALUES
('sample', 'C:\\Users\\judieballadares\\Documents\\baldwin.docx', 'C:\\Users\\judieballadares\\Documents\\baldwin.docx', 'admin', 'C:\\Program Files\\Microsoft Office\\Office12\\WINWORD.EXE/C:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('music', 'C:\\Users\\judieballadares\\Downloads\\Pop Danthology 2012 - Mashup of 50+ Pop Songs.mp3', 'C:\\Users\\judieballadares\\Downloads\\Pop Danthology 2012 - Mashup of 50+ Pop Songs.mp3', 'admin', 'C:\\Program Files\\Windows Media Player\\wmplayer.exe/C:\\Program Files\\Windows Media Player\\wmplayer.exe'),
('testing', 'C:\\Users\\judieballadares\\Documents\\ten commandments.ppt', 'C:\\Users\\judieballadares\\Documents\\ten commandments.ppt', 'grace', 'C:\\Program Files\\Microsoft Office\\Office12\\POWERPNT.EXE/C:\\Program Files\\Microsoft Office\\Office12\\POWERPNT.EXE'),
('good', 'C:\\Users\\judieballadares\\Documents\\site asp.docx', 'C:\\Users\\judieballadares\\Documents\\site asp.docx', 'joanmart', 'C:\\Program Files\\Microsoft Office\\Office12\\WINWORD.EXE/C:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('activity', 'C:\\Users\\joshua\\Documents\\10-0380.xlsx', 'C:\\Users\\joshua\\Documents\\10-0380.xlsx', 'admin', 'C:\\Program Files\\Microsoft Office\\Office12\\EXCEL.EXE/C:\\Program Files\\Microsoft Office\\Office12\\EXCEL.EXE'),
('sample', 'C:\\Users\\joshua\\Documents\\10-0380.xlsx', 'C:\\Users\\joshua\\Documents\\10-0380.xlsx', 'username', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\EXCEL.EXE/C:\\Program Files (x86)\\Microsoft Office\\Office12\\EXCEL.EXE'),
('sample', 'C:\\Users\\Public\\Documents\\DOCU IN CAPSTONE.docx', 'C:\\Users\\Public\\Documents\\DOCU IN CAPSTONE.docx', 'joan', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\WINWORD.EXE/C:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('test', 'C:\\Users\\joshua\\Documents\\abby.docx', 'C:\\Users\\joshua\\Documents\\abby.docx', 'joan', 'F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE/F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('movie', 'C:\\Users\\joshua\\Documents\\Youcam\\Capture_20140514.wmv', 'C:\\Users\\joshua\\Documents\\Youcam\\Capture_20140514.wmv', 'joan', 'C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe/C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe'),
('sample', 'C:\\Users\\joshua\\Documents\\Functionalities to be done.docx', 'C:\\Users\\joshua\\Documents\\Functionalities to be done.docx', 'rheyan', 'F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE/F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('ACTIVITY1', 'C:\\Users\\joshua\\Desktop\\Voice Command Controller for IT Laboratory.docx', 'C:\\Users\\joshua\\Desktop\\Voice Command Controller for IT Laboratory.docx', 'jeljosh', 'F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE/F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('activity1', 'C:\\Users\\joshua\\Desktop\\Latest Screen Shot.docx', 'C:\\Users\\joshua\\Desktop\\Latest Screen Shot.docx', 'jelly', 'F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE/F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_apptype`
--

CREATE TABLE IF NOT EXISTS `tbl_apptype` (
  `appname` varchar(255) NOT NULL,
  `pathname` varchar(500) NOT NULL,
  `isServer` varchar(10) NOT NULL,
  `conpath` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_apptype`
--

INSERT INTO `tbl_apptype` (`appname`, `pathname`, `isServer`, `conpath`) VALUES
('Notepad', 'C:\\Windows\\notepad.exe', 'Yes', 'C:\\Windows\\notepad.exe'),
('VLC', 'C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe', 'Yes', 'C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe'),
('Visual-Studio', 'F:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe', 'Yes', 'C:\\Program Files\\Microsoft Visual Studio 10.0\\Common7\\IDE\\devenv.exe'),
('word', 'F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE', 'Yes', 'F:\\Program Files\\Microsoft Office\\Office15\\WINWORD.EXE'),
('EXCEL', 'C:\\Program Files (x86)\\Microsoft Office\\Office12\\EXCEL.EXE', 'Yes', 'C:\\Program Files (x86)\\Microsoft Office\\Office15\\EXCEL.EXE'),
('ACCESS', 'C:\\Program Files\\Microsoft Office\\Office12\\MSACCESS.EXE', 'Yes', 'C:\\Program Files\\Microsoft Office\\Office12\\MSACCESS.EXE'),
('Powerpoint', 'C:\\Program Files\\Microsoft Office\\Office12\\POWERPNT.EXE', 'Yes', 'C:\\Program Files\\Microsoft Office\\Office12\\POWERPNT.EXE'),
('MediaPlayer', 'C:\\Program Files\\Windows Media Player\\wmplayer.exe', 'Yes', 'C:\\Program Files\\Windows Media Player\\wmplayer.exe'),
('Chrome', 'C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe', 'Yes', 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe'),
('cmd', 'C:\\Windows\\System32\\cmd.exe', 'Yes', 'C:\\Windows\\System32\\cmd.exe'),
('taskmanager', 'C:\\Windows\\System32\\taskmgr.exe', 'Yes', 'C:\\Windows\\System32\\taskmgr.exe'),
('picturemanager', 'C:\\Windows\\System32\\mspaint.exe', 'Yes', 'C:\\Windows\\System32\\mspaint.exe');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_attendance`
--

CREATE TABLE IF NOT EXISTS `tbl_attendance` (
  `studentid` varchar(50) NOT NULL,
  `loginfo` varchar(100) NOT NULL,
  `computername` varchar(255) NOT NULL,
  `major` varchar(50) NOT NULL,
  `year` varchar(50) NOT NULL,
  `section` varchar(50) NOT NULL,
  `subject` varchar(100) NOT NULL,
  `accountuser` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_attendance`
--

INSERT INTO `tbl_attendance` (`studentid`, `loginfo`, `computername`, `major`, `year`, `section`, `subject`, `accountuser`) VALUES
('11-2408', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1388', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-2463', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1629', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-2022', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12--0238', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-2248', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-1557', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1060', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-1585', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-1123', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('ABCD-12', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-0625', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-1598', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-0426', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-0363', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('09-3420', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('10-0181', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1709', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1987', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-2582', '2/6/2015', 'JOSHUA-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-0000', '2/6/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1945', '2/9/2015', 'MIGUEL-PC', 'CS', '4', 'C', 'TELECOM', 'joanmart'),
('11-1945', '2/9/2015', 'MIGUEL-PC', 'CS', '4', 'C', 'TELECOM', 'joanmart'),
('11-1945', '2/9/2015', 'MIGUEL-PC', 'CS', '4', 'C', 'TELECOM', 'joanmart'),
('10-0576', '2/9/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('11-1111', '2/9/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('10-1126', '2/10/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('10-1126', '2/10/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('10-6789', '2/10/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('12-3456', '2/10/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('90-0909', '2/11/2015', 'MIGUEL-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('90-0909', '2/11/2015', 'MIGUEL-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('90-0909', '2/11/2015', 'MIGUEL-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('23-4567', '2/10/2015', 'CARLPC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('90-0909', '2/11/2015', 'MIGUEL-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('90-0909', '2/11/2015', 'MIGUEL-PC', 'IS', '4', '1', 'Ecommerce', 'admin'),
('10-0576', '2/11/2015', 'MIGUEL-PC', 'CT', '4', 'B', 'Mobile Programming', 'admin'),
('10-0381', '2/10/2015', 'CARLPC', 'CT', '4', 'B', 'Mobile Programming', 'admin'),
('10-0576', '2/10/2015', 'CARLPC', 'CT', '4', 'B', 'Mobile Programming', 'admin'),
('77-7777', '2/10/2015', 'CARLPC', 'CT', '4', 'B', 'Mobile Programming', 'admin'),
('10-1103', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1126', '2/15/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1127', '2/15/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('77-7777', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('78-7878', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('78-7878', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('77-7777', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1127', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-1111', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-3456', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('33-3333', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('09-3612', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1010', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1111', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1010', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-3223', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-1060', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-2248', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1585', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-0625', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-2022', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1598', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1124', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1557', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1374', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1365', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-2023', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-2023', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1848', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1255', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-0576', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('09-1111', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1824', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1738', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-2031', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1824', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1824', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-0109', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-0084', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-0532', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('12-1234', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-0510', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-0584', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('10-1777', '2/16/2015', 'JOSHUA-PC', 'CS', '4', 'C', 'TELECOM', 'username'),
('11-2185', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'test'),
('11-1735', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'test'),
('13-0000', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'test'),
('10-0043', '2/16/2015', 'NUNA-PC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-1317', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'test'),
('12-0087', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3421', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-1317', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3421', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'test'),
('11-1111', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-0909', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3612', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-0909', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3612', '2/16/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-0909', '2/16/2015', 'CARLPC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3612', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3613', '2/16/2015', 'ACER-PC', 'CS', '4', 'C', 'TELECOM', 'test'),
('09-3421', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-1168', '2/17/2015', 'CARLPC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('09-3421', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('09-3421', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('09-3421', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('09-3422', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-1234', '2/17/2015', 'CARLPC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('09-3422', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('09-3423', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0240', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0240', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-2299', '2/17/2015', 'CARLPC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0043', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-2299', '2/17/2015', 'CARLPC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0043', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0001', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-2299', '2/17/2015', 'CARLPC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0001', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0001', '2/17/2015', 'JUDIE', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0043', '2/17/2015', 'NUNA-PC', 'CS', '4', 'C', 'ASP', 'jeanel'),
('10-0181', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('09-3421', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('09-3421', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0182', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/17/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0240', '2/17/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0240', '2/17/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0240', '2/17/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0182', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/17/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0182', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/17/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-0987', '2/17/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1715', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('12-3184', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('12-2104', '2/17/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1548', '2/17/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/17/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1548', '2/17/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0182', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0182', '2/17/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/17/2015', 'NUNA-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0301', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0301', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0301', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0301', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0576', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('12-1305', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('12-1419', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0938', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-9754', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('12-1466', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('12-3193', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('09-3424', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0282', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0839', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0839', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('', '2/18/2015', 'CARLPC', '', '', '', '', ''),
('10-1103', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0576', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1850', '2/18/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1624', '2/18/2015', 'CARLPC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-0968', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1212', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0095', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1352', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1352', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0258', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0816', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-7876', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1345', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0043', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1345', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-2795', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-2236', '2/20/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('11-1504', '2/20/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/21/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-0095', '2/21/2015', 'ACER-PC', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/21/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('10-1103', '2/21/2015', 'JUDIE', 'CS', '4', 'c', 'graphics design', 'joan'),
('09-3421', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-3456', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-1103', '2/21/2015', 'MIGUEL-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('09-3421', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-1103', '2/21/2015', 'MIGUEL-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0043', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-3456', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-1103', '2/21/2015', 'MIGUEL-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0043', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-1103', '2/21/2015', 'MIGUEL-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-3456', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-1103', '2/21/2015', 'MIGUEL-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-3456', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0043', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-1103', '2/21/2015', 'MIGUEL-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0043', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-3456', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0043', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0043', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-3456', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'joan'),
('10-0240', '2/21/2015', 'ACER-PC', 'CS', '4', 'B', 'TELECOM', 'rheyan'),
('10-9876', '2/21/2015', 'JUDIE', 'CS', '4', 'B', 'TELECOM', 'rheyan'),
('10-1103', '2/23/2015', 'JUDIE', 'CS', '4', 'C', 'TELECOM', 'joanmart5711'),
('10-0301', '2/24/2015', 'ACER-PC', '', '4', 'C', 'java', 'joanjoan'),
('11-1548', '2/24/2015', 'JUDIE', '', '4', 'C', 'java', 'joanjoan');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_commandpc`
--

CREATE TABLE IF NOT EXISTS `tbl_commandpc` (
  `computername` varchar(100) NOT NULL,
  `ipaddress` varchar(255) NOT NULL,
  `commandpc` varchar(1000) NOT NULL,
  `concommand` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_commandpc`
--

INSERT INTO `tbl_commandpc` (`computername`, `ipaddress`, `commandpc`, `concommand`) VALUES
('CARLPC', '169.254.232.188', 'add', '120'),
('CARLPC', '169.254.232.188', 'add', '360');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_computer`
--

CREATE TABLE IF NOT EXISTS `tbl_computer` (
  `wordcall` varchar(50) NOT NULL,
  `computername` varchar(100) NOT NULL,
  `ipaddress` varchar(255) NOT NULL,
  `actdone` varchar(50) NOT NULL,
  `imageport` varchar(255) NOT NULL,
  PRIMARY KEY (`wordcall`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_computer`
--

INSERT INTO `tbl_computer` (`wordcall`, `computername`, `ipaddress`, `actdone`, `imageport`) VALUES
('pc1', 'ACER-PC', '169.254.237.32', 'Yes', '808'),
('pc2', 'JUDIE', '169.254.5.194', 'Yes', '13'),
('server', 'JOSHUA-PC', '169.254.87.145', 'Yes', '1022');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_keyword`
--

CREATE TABLE IF NOT EXISTS `tbl_keyword` (
  `keywordcall` varchar(100) NOT NULL,
  `toprint` varchar(500) NOT NULL,
  `accountuser` varchar(100) NOT NULL,
  `isSystem` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_keyword`
--

INSERT INTO `tbl_keyword` (`keywordcall`, `toprint`, `accountuser`, `isSystem`) VALUES
('enter', '{ENTER}', '', 'Yes'),
('backspace', '{BS}', '', 'Yes'),
('select-all', '^a', '', 'Yes'),
('delete', '{DEL}', '', 'Yes'),
('space', '{SPACE}', '', 'Yes'),
('escape', '{ESC}', '', 'Yes'),
('run', '{F5}', '', 'Yes'),
('close', '%{F4}', '', 'Yes'),
('undo', '^z', '', 'Yes'),
('redo', '^y', '', 'Yes'),
('left', '{LEFT}', '', 'Yes'),
('right', '{RIGHT}', '', 'Yes'),
('up', '{UP}', '', 'Yes'),
('down', '{DOWN}', '', 'Yes'),
('shiftup', '+{UP}', '', 'Yes'),
('shiftleft', '+{LEFT}', '', 'Yes'),
('shiftright', '+{RIGHT}', '', 'Yes'),
('shiftdown', '+{DOWN}', '', 'Yes'),
('controlbackspace', '^{BS}', '', 'Yes'),
('controlleft', '^{LEFT}', '', 'Yes'),
('controlright', '^{RIGHT}', '', 'Yes'),
('alt', '%', '', 'Yes'),
('save', '^s', '', 'Yes'),
('home', '{HOME}', '', 'Yes'),
('shifthome', '+{HOME}', '', 'Yes'),
('shiftend', '+{END}', '', 'Yes'),
('tab', '{TAB}', '', 'Yes'),
('view', '{f5}', 'admin', 'No'),
('html', '<HTML>', 'admin', 'No'),
('body', '<BODY>', 'admin', 'No');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_login`
--

CREATE TABLE IF NOT EXISTS `tbl_login` (
  `studentid` varchar(100) NOT NULL,
  `pcname` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_login`
--

INSERT INTO `tbl_login` (`studentid`, `pcname`) VALUES
('10-1103', 'MIGUEL-PC'),
('10-4321', 'CARLPC');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_oncreate`
--

CREATE TABLE IF NOT EXISTS `tbl_oncreate` (
  `onCreate` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_oncreate`
--

INSERT INTO `tbl_oncreate` (`onCreate`) VALUES
('No');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_schedule`
--

CREATE TABLE IF NOT EXISTS `tbl_schedule` (
  `accountuser` varchar(20) NOT NULL,
  `major` varchar(10) NOT NULL,
  `year` varchar(5) NOT NULL,
  `section` varchar(10) NOT NULL,
  `subject` varchar(100) NOT NULL,
  `daysched` varchar(50) NOT NULL,
  `dayin` varchar(20) NOT NULL,
  `dayout` varchar(20) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_schedule`
--

INSERT INTO `tbl_schedule` (`accountuser`, `major`, `year`, `section`, `subject`, `daysched`, `dayin`, `dayout`, `status`) VALUES
('admin', 'IS', '4', '1', 'Ecommerce', 'Monday', '7:00 AM', '10:00 AM', 'Offline'),
('jayjay', ' ', '4', 'D', 'TELECOM', 'Wednesday', '7:00 AM', '10:00 AM', 'Offline'),
('jayjay', '', '4', 'C', 'TELECOM', 'Wednesday', '10:00 AM', '1:00 PM', 'Offline'),
('Jay', 'IS', '4', 'A', 'Thesis', 'Monday', '11:00 AM', '2:00 PM', 'Offline'),
('Jay', 'CS', '3', 'A', 'Thesis', 'Wednesday', '1:00 PM', '4:00 PM', 'Offline'),
('grace', 'CS', '4', 'D', 'MULTIMEDIA', 'Friday', '7:00 AM', '10:00 AM', 'Offline'),
('admin', 'CT', '4', 'D', 'Microprocessor', 'Saturday', '12:00 PM', '3:00 PM', 'Offline'),
('admin', 'CT', '4', 'B', 'Mobile Programming', 'Saturday', '4:00 PM', '7:00 PM', 'Offline'),
('admin', 'CS', '4', 'C', 'TELECOM', 'Thursday', '1:00 PM', '4:00 PM', 'Offline'),
('joanmart', 'CS', '4', 'C', 'TELECOM', 'Tuesday', '9:00 AM', '12:00 PM', 'Offline'),
('username', 'CS', '4', 'C', 'TELECOM', 'Wednesday', '4:00 PM', '7:00 PM', 'Offline'),
('test', 'CS', '4', 'C', 'TELECOM', 'Thursday', '9:00 AM', '12:00 PM', 'Offline'),
('jeanel', 'CS', '4', 'C', 'ASP', 'Friday', '4:00 PM', '7:00 PM', 'Offline'),
('joan', 'CS', '4', 'c', 'graphics design', 'Saturday', '7:00 AM', '10:00 AM', 'Offline'),
('joan', 'CS', '4', 'B', 'TELECOM', 'Monday', '2:00 PM', '5:00 PM', 'Offline'),
('rheyan', 'CS', '4', 'B', 'TELECOM', 'Tuesday', '6:00 AM', '9:00 AM', 'Offline'),
('rheyan', 'IS', '3', 'A', 'Graphics Design', 'Thursday', '6:00 PM', '9:00 PM', 'Offline'),
('jeljosh', 'CT', '4', 'C', 'COMTECH', 'Monday', '5:00 PM', '8:00 PM', 'Offline'),
('joanmart5711', 'CS', '4', 'C', 'TELECOM', 'Sunday', '9:00 AM', '12:00 PM', 'Offline'),
('jelly', 'CS', '3', 'a', 'asp', 'Tuesday', '4:00 PM', '7:00 PM', 'Offline'),
('joanjoan', '', '4', 'C', 'java', 'Sunday', '1:00 PM', '4:00 PM', 'Offline'),
('joanjoan', 'IS', '4', 'C', 'TELECOM', 'Sunday', '4:00 PM', '7:00 PM', 'Offline'),
('Joy', '', '2', 'a', 'wala', 'Monday', '4:00 AM', '7:00 AM', 'Offline');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_setting`
--

CREATE TABLE IF NOT EXISTS `tbl_setting` (
  `username` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_setting`
--

INSERT INTO `tbl_setting` (`username`) VALUES
('judieballadares');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_student`
--

CREATE TABLE IF NOT EXISTS `tbl_student` (
  `studentid` varchar(100) NOT NULL,
  `studentlname` varchar(100) NOT NULL,
  `studentfname` varchar(100) NOT NULL,
  `studentmname` varchar(100) NOT NULL,
  `major` varchar(10) NOT NULL,
  `year` varchar(2) NOT NULL,
  `section` varchar(10) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `studentpass` varchar(100) NOT NULL,
  `accountuser` varchar(100) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_student`
--

INSERT INTO `tbl_student` (`studentid`, `studentlname`, `studentfname`, `studentmname`, `major`, `year`, `section`, `subject`, `studentpass`, `accountuser`, `status`) VALUES
('11-2408', 'Bagadiong', 'Ashley Shanne', 'Traquena', 'IS', '4', '1', 'Ecommerce', '1111', 'admin', 'Online'),
('11-2463', 'rivas', 'james', 'gracio', 'IS', '4', '1', 'Ecommerce', 'akojames', 'admin', 'Offline'),
('11-1388', 'Tambal', 'Angelica', 'Labarda', 'IS', '4', '1', 'Ecommerce', 'asdfg', 'admin', 'Offline'),
('11-1629', 'Alano', 'Aubrey', 'Lim', 'IS', '4', '1', 'Ecommerce', 'aubrey', 'admin', 'Offline'),
('12-2022', 'Villamor', 'Paolo', 'Abio', 'IS', '4', '1', 'Ecommerce', 'cannabissativa', 'admin', 'Offline'),
('12--0238', 'sanosa', 'marjorie', 'm', 'IS', '4', '1', 'Ecommerce', '1234', 'admin', 'Offline'),
('12-1557', 'palermo', 'tricia marie', 'Nieves', 'IS', '4', '1', 'Ecommerce', '123', 'admin', 'Offline'),
('12-2248', 'Anzano', 'John Renzo', 'Amandy', 'IS', '4', '1', 'Ecommerce', 'bakaenzto07', 'admin', 'Offline'),
('11-1060', 'Nicer', 'Rey Francis', 'Isla', 'IS', '4', '1', 'Ecommerce', 'test', 'admin', 'Offline'),
('12-1585', 'militante', 'soji', 'tagabi', 'IS', '4', '1', 'Ecommerce', '1234', 'admin', 'Offline'),
('12-1123', 'Gega', 'Jeroh', 'Carino', 'IS', '4', '1', 'Ecommerce', 'emihonokalillyrinshizunekatawashoujo', 'admin', 'Offline'),
('ABCD-12', 'Silos', 'Jasper Kurt', 'Silos', 'IS', '4', '1', 'Ecommerce', 'jasper', 'admin', 'Offline'),
('12-0625', 'Tauro', 'Rainier', 'Solomon', 'IS', '4', '1', 'Ecommerce', 'neversm1le', 'admin', 'Offline'),
('12-1598', 'eufracio', 'reychristian', 'segismundo', 'IS', '4', '1', 'Ecommerce', 'helloworld', 'admin', 'Offline'),
('12-0363', 'ganit', 'airah', 'carolino', 'IS', '4', '1', 'Ecommerce', 'airahganit', 'admin', 'Offline'),
('12-0426', 'ogawa', 'mark', 'caballes', 'IS', '4', '1', 'Ecommerce', 'qwerty', 'admin', 'Offline'),
('11-1987', 'Odtojan', 'Jayphvavenn', 'Noel', 'IS', '4', '1', 'Ecommerce', 'vastogrande', 'admin', 'Offline'),
('11-1709', 'Fabicon', 'Gabriel', 'Carig', 'IS', '4', '1', 'Ecommerce', 'gab', 'admin', 'Offline'),
('11-0000', 'Yaun', 'Zel', 'Del', 'IS', '4', '1', 'Ecommerce', '123456789', 'admin', 'Offline'),
('11-2582', 'Punay', 'Jaymar', 'Galindo', 'IS', '4', '1', 'Ecommerce', 'jaymarpunz', 'admin', 'Offline'),
('10-0043', 'askdihqwl', 'lksjds', 'xndju', 'IS', '4', '1', 'Ecommerce', '111', 'admin', 'Offline'),
('11-1419', 'Bugarin', 'Ar Felip', 'D', 'CT', '4', 'D', 'Microprocessor', '11-1419', 'admin', 'Offline'),
('11-1398', 'Arriola', 'Jerico', '', 'CT', '4', 'D', 'Microprocessor', '11-1398', 'admin', 'Offline'),
('11-1543', 'Del Mundo', 'Gerald', 'O', 'CT', '4', 'D', 'Microprocessor', '11-1543', 'admin', 'Offline'),
('11-1990', 'Belarmino', 'Bhelmier', 'M', 'CT', '4', 'D', 'Microprocessor', '11-1990', 'admin', 'Offline'),
('11-1448', 'lozada', 'Aldrin', 'P', 'CT', '4', 'D', 'Microprocessor', 'aldrin', 'admin', 'Offline'),
('11-1769', 'Lingat', 'Rahf Kevin', 'S', 'CT', '4', 'D', 'Microprocessor', '11-1769', 'admin', 'Offline'),
('11-1505', 'Baranda', 'Cherwin', 'L', 'CT', '4', 'D', 'Microprocessor', 'Baranda', 'admin', 'Offline'),
('11-1679', 'Dela Vega', 'John Martin', 'S', 'CT', '4', 'D', 'Microprocessor', '11-1679', 'admin', 'Offline'),
('11-2160', 'Movida', 'Mariz', 'A', 'CT', '4', 'D', 'Microprocessor', '11-2160', 'admin', 'Offline'),
('11-2566', 'Dula', 'Ruby Rose', 'D', 'CT', '4', 'D', 'Microprocessor', '11-2566', 'admin', 'Offline'),
('11-1813', 'Escoto', 'Joanna', '', 'CT', '4', 'D', 'Microprocessor', '11-1813', 'admin', 'Offline'),
('11-2047', 'Remegio', 'Raffy', '', 'CT', '4', 'D', 'Microprocessor', '11-2047', 'admin', 'Offline'),
('11-1945', 'Demayo', 'Moises', 'L', 'CT', '4', 'D', 'Microprocessor', 'Demayo', 'admin', 'Offline'),
('11-2887', 'Rodriguez', 'Katherine', 'O', 'CT', '4', 'D', 'Microprocessor', '11-2887', 'admin', 'Offline'),
('09-1868', 'Albino', 'Chris', 'T', 'CT', '4', 'D', 'Microprocessor', 'Albino', 'admin', 'Offline'),
('10-3251', 'Ortego', 'Jerry', 'P', 'CT', '4', 'D', 'Microprocessor', '10-3251', 'admin', 'Offline'),
('09-0491', 'Martizano', 'Celyne', 'J', 'CT', '4', 'D', 'Microprocessor', '09-0491', 'admin', 'Offline'),
('11-2981', 'Racelis', 'Lea Jay', 'R', 'CT', '4', 'D', 'Microprocessor', 'Racelis', 'admin', 'Offline'),
('11-1455', 'Palado', 'Jake Ryan', 'N', 'CT', '4', 'D', 'Microprocessor', '11-1455', 'admin', 'Offline'),
('11-2362', 'Dela Pacian', 'Jenny', 'L', 'CT', '4', 'D', 'Microprocessor', '11-2362', 'admin', 'Offline'),
('12-2657', 'Lim', 'Raymund', '', 'CT', '4', 'D', 'Microprocessor', '12-2657', 'admin', 'Offline'),
('11-1643', 'Edejer', 'Rachel', 'A', 'CT', '4', 'D', 'Microprocessor', 'Edejer', 'admin', 'Offline'),
('10-1273', 'Capistrano', 'Jayson', 'S', 'CT', '4', 'D', 'Microprocessor', '10-1273', 'admin', 'Offline'),
('11-1817', 'Millagracia', 'Nina', 'G', 'CT', '4', 'D', 'Microprocessor', 'Nina', 'admin', 'Offline'),
('09-2880', 'Palero', 'Jayson', 'P', 'CT', '4', 'D', 'Microprocessor', 'Paler', 'admin', 'Offline'),
('11-2191', 'Estabillo', 'Richard', '', 'CT', '4', 'B', 'Mobile Programming', '11-2191', 'admin', 'Offline'),
('11-2872', 'Eleserio', 'Gueneverre', 'C', 'CT', '4', 'B', 'Mobile Programming', 'Eleserio', 'admin', 'Offline'),
('10-0965', 'Mangalos', 'Ronnel', '', 'CT', '4', 'B', 'Mobile Programming', '10-0965', 'admin', 'Offline'),
('10-3257', 'Ramilos', 'Jenneth', 'R', 'CT', '4', 'B', 'Mobile Programming', 'Ramilos', 'admin', 'Offline'),
('11-2135', 'Dycaigo', 'John Paolo', '', 'CT', '4', 'B', 'Mobile Programming', '11-2135', 'admin', 'Offline'),
('11-1505', 'Baranda', 'Cherwin', 'L', 'CT', '4', 'B', 'Mobile Programming', '11-1505', 'admin', 'Offline'),
('12-1978', 'Dalusong', 'John Floyd', '', 'CT', '4', 'B', 'Mobile Programming', '12-1978', 'admin', 'Offline'),
('11-1448', 'Lazada', 'Aldrin', 'P', 'CT', '4', 'B', 'Mobile Programming', 'Lazada', 'admin', 'Offline'),
('11-1813', 'Escoto', 'Joanna', '', 'CT', '4', 'B', 'Mobile Programming', '11-1813', 'admin', 'Offline'),
('11-1419', 'Bayarin', 'Ar Felijo', 'D', 'CT', '4', 'B', 'Mobile Programming', '11-1419', 'admin', 'Offline'),
('11-2047', 'Remegio', 'Raffy', '', 'CT', '4', 'B', 'Mobile Programming', '11-2047', 'admin', 'Offline'),
('11-1455', 'Palado', 'Jake Ryan', 'N', 'CT', '4', 'B', 'Mobile Programming', '11-1455', 'admin', 'Offline'),
('11-1945', 'Denayo', 'Moises', 'L', 'CT', '4', 'B', 'Mobile Programming', '11-1945', 'admin', 'Offline'),
('11-1398', 'Arriola', 'Jerico', 'D', 'CT', '4', 'B', 'Mobile Programming', 'Arriola', 'admin', 'Offline'),
('11-2160', 'Movida', 'Mariz', 'A', 'CT', '4', 'B', 'Mobile Programming', '11-2160', 'admin', 'Offline'),
('09-1868', 'Albino', 'Chris', 'T', 'CT', '4', 'B', 'Mobile Programming', '09-1868', 'admin', 'Offline'),
('11-1769', 'Lingat', 'Rahf Kevin', 'S', 'CT', '4', 'B', 'Mobile Programming', '11-1769', 'admin', 'Offline'),
('11-1543', 'Del', 'Mundo', 'Gerald', 'CT', '4', 'B', 'Mobile Programming', 'Gerald', 'admin', 'Offline'),
('11-1679', 'Dela Vega', 'John Martin', 'E', 'CT', '4', 'B', 'Mobile Programming', '11-1679', 'admin', 'Offline'),
('11-2362', 'Dela Pacian', 'Jenny', 'L', 'CT', '4', 'B', 'Mobile Programming', '11-2362', 'admin', 'Offline'),
('10-1374', 'Serrano', 'Kashmr', 'V', 'CS', '4', 'C', 'TELECOM', 'Serrano', 'admin', 'Offline'),
('10-3257', 'Ramilos', 'Jenneth', 'R', 'CS', '4', 'C', 'TELECOM', 'Jenneth', 'admin', 'Offline'),
('11-2135', 'Dycaico', 'Jonh', 'Paolo', 'CS', '4', 'C', 'TELECOM', 'Jonh', 'admin', 'Offline'),
('12-1978', 'Dalusong', 'John Flloyd', 'C', 'CS', '4', 'C', 'TELECOM', 'Dalusong', 'admin', 'Offline'),
('11-1502', 'Madali', 'Cristian', 'C', 'CS', '4', 'C', 'TELECOM', 'Madali', 'admin', 'Offline'),
('11-1448', 'Lozada', 'Aldrin', 'P', 'CS', '4', 'C', 'TELECOM', 'Lozada', 'admin', 'Offline'),
('11-1505', 'Baranda', 'Cherwin', 'L', 'CS', '4', 'C', 'TELECOM', 'Barand', 'admin', 'Offline'),
('11-2160', 'Movida', 'Mariz', 'A', 'CS', '4', 'C', 'TELECOM', '11-2160', 'admin', 'Offline'),
('10-3251', 'Ortego', 'Jerray', 'P', 'CS', '4', 'C', 'TELECOM', 'Ortego', 'admin', 'Offline'),
('11-2887', 'Rodriguez', 'Latherine', 'O', 'CS', '4', 'C', 'TELECOM', 'Latherine', 'admin', 'Offline'),
('11-1990', 'Belarmino', 'Bhelmeir', 'M', 'CS', '4', 'C', 'TELECOM', 'Bhelmeir', 'admin', 'Offline'),
('11-1398', 'Arriola', 'Jericho', 'Dl', 'CS', '4', 'C', 'TELECOM', 'Arriola', 'admin', 'Offline'),
('11-1543', 'Del mUndo', 'Gerald', 'O', 'CS', '4', 'C', 'TELECOM', 'Gerald', 'admin', 'Offline'),
('09-1868', 'Albino', 'Chris', 'T', 'CS', '4', 'C', 'TELECOM', 'Chris', 'admin', 'Offline'),
('11-2981', 'Racelis', 'Lea Jay', 'R', 'CS', '4', 'C', 'TELECOM', 'Racelis', 'admin', 'Offline'),
('11-1769', 'Lingat', 'Raft Kewin', 'S', 'CS', '4', 'C', 'TELECOM', 'Lingat', 'admin', 'Offline'),
('11-1679', 'Lingat', 'Rahf', 'S', 'CS', '4', 'C', 'TELECOM', 'Kevin', 'admin', 'Offline'),
('11-2862', 'Delo Pacian', 'Jenny', 'L', 'CS', '4', 'C', 'TELECOM', 'Jenny', 'admin', 'Offline'),
('11-1455', 'Palado', 'Jake Ryan', 'N', 'CS', '4', 'C', 'TELECOM', 'Palado', 'admin', 'Offline'),
('09-0491', 'Martizano', 'Celyne', 'J', 'CS', '4', 'C', 'TELECOM', 'CElyne', 'admin', 'Offline'),
('11-2047', 'Remeglo', 'Raffy', 'D', 'CS', '4', 'C', 'TELECOM', 'Raffy', 'admin', 'Offline'),
('11-1814', 'Escoto', 'Joana', 'A', 'CS', '4', 'C', 'TELECOM', 'Joana', 'admin', 'Offline'),
('11-2566', 'Dula', 'Riby', 'D', 'CS', '4', 'C', 'TELECOM', 'Ruby', 'admin', 'Offline'),
('10-3258', 'Ramilo', 'Jenneth', 'R', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('11-2139', 'Dyaico', 'John Paolo', 'T', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('12-1970', 'Dalusong', 'John Flloyd', 'B', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('11-5005', 'Madali', 'Cristian', 'M', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('11-1449', 'Lozada', 'Aldrin', 'A', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('11-1507', 'Baranda', 'Cherwin', 'L', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('11-1956', 'Demayo', 'Moises', 'M', 'CS', '4', 'C', 'TELECOM', 'qwe', 'admin', 'Offline'),
('11-1945', 'Demayo', 'Moises', 'L', 'CS', '4', 'C', 'TELECOM', '11-1945', 'joanmart', 'Offline'),
('10-0576', 'barca', 'barca', 'barca', 'IS', '4', '1', 'Ecommerce', 'barca', 'admin', 'Offline'),
('10-0240', 'Yumang', 'Joy', 'Doctor', 'IS', '4', '1', 'Ecommerce', '1234', 'admin', 'Offline'),
('11-1111', 'q', 'q', 'qq', 'IS', '4', '1', 'Ecommerce', 'q', 'admin', 'Offline'),
('10-1126', 'Morandarte', 'Ray Mart', 'Tatad', 'IS', '4', '1', 'Ecommerce', 'mamart', 'admin', 'Offline'),
('10-1103', 'Lachica', 'Joan Kristle', 'Bacay', 'IS', '4', '1', 'Ecommerce', '10-1103', 'admin', 'Offline'),
('00-0000', 'barca', 'barca', 'barca', 'IS', '4', '1', 'Ecommerce', 'barca', 'admin', 'Online'),
('10-6789', 'Morandarte', 'Ray Mart', 'Tatad', 'IS', '4', '1', 'Ecommerce', 'mamart', 'admin', 'Offline'),
('90-0909', 'barca', 'barca', 'barca', 'IS', '4', '1', 'Ecommerce', 'barca', 'admin', 'Offline'),
('12-3456', 'Sample', 'Sample', 'Sample', 'IS', '4', '1', 'Ecommerce', '12345', 'admin', 'Offline'),
('09-8765', 'sample', 'sample', 'sample', 'IS', '4', '1', 'Ecommerce', '1234', 'admin', 'Online'),
('12-3457', 'sample', 'sample', 'sample', 'IS', '4', '1', 'Ecommerce', '1234', 'admin', 'Offline'),
('23-4567', 'sample', 'sample', 'sample', 'IS', '4', '1', 'Ecommerce', '1234', 'admin', 'Offline'),
('99-9999', 'mart', 'mart', 'mart', 'IS', '4', '1', 'Ecommerce', 'mart', 'admin', 'Offline'),
('55-5555', 'mart', 'mart', 'mart', 'IS', '4', '1', 'Ecommerce', 'mart', 'admin', 'Offline'),
('88-8888', 'p', 'p', 'p', 'IS', '4', '1', 'Ecommerce', 'p', 'admin', 'Offline'),
('77-7777', 'mart', 'mart', 'mart', 'IS', '4', '1', 'Ecommerce', 'mart', 'admin', 'Offline'),
('45-4545', 'mart', 'mart', 'mart', 'IS', '4', '1', 'Ecommerce', 'mart', 'admin', 'Offline'),
('10-0380', 'Abrenica', 'Mark Joshua', 'Rivera', 'IS', '4', '1', 'Ecommerce', 'abrenica', 'admin', 'Offline'),
('10-0381', 'abrenica', 'dan joel', 'rivera', 'CT', '4', 'B', 'Mobile Programming', 'abrenica', 'admin', 'Offline'),
('10-0576', 'Barca', 'Carlo Jay', 'Caceres', 'CT', '4', 'B', 'Mobile Programming', 'barca', 'admin', 'Offline'),
('77-7777', 'barca', 'b', 'b', 'CT', '4', 'B', 'Mobile Programming', 'b', 'admin', 'Offline'),
('09-4012', 'Magat', 'Miguel', 'B', 'CS', '4', 'C', 'TELECOM', 'qwe', 'username', 'Online'),
('10-1126', 'Morandarte', 'Ray Mart', 'Tatad', 'CS', '4', 'C', 'TELECOM', 'mamart', 'username', 'Online'),
('10-1103', 'lachica', 'joan', 'bacay', 'CS', '4', 'C', 'TELECOM', 'joanmart', 'username', 'Offline'),
('77-7777', 'Sample', 'Sample', 'Sample', 'CS', '4', 'C', 'TELECOM', '7', 'username', 'Offline'),
(' 1-1126', 'raymart', 'morandarte', '', 'CS', '4', 'C', 'TELECOM', 'joanmart', 'username', 'Offline'),
('10-1127', 'raymart', 'morandarte', '', 'CS', '4', 'C', 'TELECOM', 'joanmart', 'username', 'Offline'),
('78-7878', 'as', 'as', 'as', 'CS', '4', 'C', 'TELECOM', 'as', 'username', 'Offline'),
('12-3456', 'A', 'a', 'a', 'CS', '4', 'C', 'TELECOM', 'a', 'username', 'Offline'),
('11-1111', 'am', 'am', 'am', 'CS', '4', 'C', 'TELECOM', 'am', 'username', 'Offline'),
('11-1133', 'm', 'm', 'm', 'CS', '4', 'C', 'TELECOM', 'm', 'username', 'Offline'),
('33-3333', 'm', 'm', 'm', 'CS', '4', 'C', 'TELECOM', 'm', 'username', 'Offline'),
('09-3612', 'Brans', 'den', 'cas', 'CS', '4', 'C', 'TELECOM', 'cas', 'username', 'Offline'),
('10-1010', 'jo', 'jo', 'jo', 'CS', '4', 'C', 'TELECOM', 'jo', 'username', 'Offline'),
('10-0576', 'barca', 'carlo jay', 'caceres', 'CS', '4', 'C', 'TELECOM', 'barca', 'username', 'Offline'),
('10-1111', 'an', 'an', 'an', 'CS', '4', 'C', 'TELECOM', 'an', 'username', 'Offline'),
('11-1060', 'Nicer', 'Rey Francis', 'Isla', 'CS', '4', 'C', 'TELECOM', 'test', 'username', 'Offline'),
('12-2248', 'Anzano', 'John Renzo', 'Amandy', 'CS', '4', 'C', 'TELECOM', '09095480355', 'username', 'Offline'),
('12-3223', 'Ocampo', 'Yves', 'De Guzman', 'CS', '4', 'C', 'TELECOM', 'ocampo', 'username', 'Offline'),
('12-0625', 'Tauro', 'Rainier', 'Solomon', 'CS', '4', 'C', 'TELECOM', 'neversm1le', 'username', 'Offline'),
('12-2022', 'Villamor', 'Paolo', 'Abio', 'CS', '4', 'C', 'TELECOM', 'paolo', 'username', 'Offline'),
('12-1585', 'militante', 'zogie', 'tagabi', 'CS', '4', 'C', 'TELECOM', 'lopi6602145', 'username', 'Offline'),
('12-1557', 'palermo', 'tricia marie', 'nieves', 'CS', '4', 'C', 'TELECOM', '1234', 'username', 'Offline'),
('12-1598', 'eufracio', 'rey christian', 'segismundo', 'CS', '4', 'C', 'TELECOM', 'kerokerokeroppi', 'username', 'Offline'),
('12-1124', 'Gega', 'Jeroh', 'Carino', 'CS', '4', 'C', 'TELECOM', 'xE7g8ix6', 'username', 'Offline'),
('10-1374', 'serano', 'kashmir', 'vedad', 'CS', '4', 'C', 'TELECOM', 'serrano', 'username', 'Offline'),
('12-2023', 'Montano', 'Brin Jarm', 'Nona', 'CS', '4', 'C', 'TELECOM', 'montano', 'username', 'Offline'),
('12-1365', 'flores', 'rojennil', 'salazar', 'CS', '4', 'C', 'TELECOM', 'ahikawpalayan', 'username', 'Offline'),
('12-1255', 'Llantino', 'Elmansam', 'Ciabu', 'CS', '4', 'C', 'TELECOM', 'ganda', 'username', 'Offline'),
('12-0426', 'ogawa', 'mark', '', 'CS', '4', 'C', 'TELECOM', '1234567890', 'username', 'Online'),
('12-1848', 'muros', 'judy anne', 'pajarellano', 'CS', '4', 'C', 'TELECOM', 'tomriddle', 'username', 'Offline'),
('12-2031', 'Quimora', 'Evangeline', 'Sugabo', 'CS', '4', 'C', 'TELECOM', 'gie', 'username', 'Offline'),
('12-1824', 'Trabado', 'Michelle', 'Almeria', 'CS', '4', 'C', 'TELECOM', 'mitch', 'username', 'Offline'),
('12-1738', 'Septuado', 'Rachel', 'Pascua', 'CS', '4', 'C', 'TELECOM', 'cheche', 'username', 'Offline'),
('09-1111', 'barca', 'carlo jay', 'caceres', 'CS', '4', 'C', 'TELECOM', 'barca', 'username', 'Offline'),
('11-0109', 'Danao', 'Maria Jennielyn', 'Bugo', 'CS', '4', 'C', 'TELECOM', 'love', 'username', 'Offline'),
('11-0084', 'paculba', 'Marian Mae', 'Pojas', 'CS', '4', 'C', 'TELECOM', 'marian', 'username', 'Offline'),
('11-0532', 'macapanas', 'rowena', 'billante', 'CS', '4', 'C', 'TELECOM', 'rowena', 'username', 'Offline'),
('12-1234', 'salazar', 'lian carlo', 'alcantara', 'CS', '4', 'C', 'TELECOM', 'qwerty', 'username', 'Offline'),
('11-0510', 'cua', 'jaeronpaul', 'paras', 'CS', '4', 'C', 'TELECOM', '12345', 'username', 'Offline'),
('11-0584', 'Jorquia', 'Ana Margarita', 'Emilanan', 'CS', '4', 'C', 'TELECOM', 'kahit', 'username', 'Offline'),
('  -', 'Morandarte', 'Ray Mart', 'Tatad', 'CS', '4', 'C', 'TELECOM', 'mamart', 'username', 'Offline'),
('10-1777', 'Morandarte', 'Morandarte', 'Morandarte', 'CS', '4', 'C', 'TELECOM', 'morandarte', 'username', 'Online'),
('10-0576', 'barca', 'carlo jay', 'caceres', 'CS', '4', 'C', 'TELECOM', 'barca', 'test', 'Offline'),
('10-1106', 'lachica', 'kristel', 'bacay', 'CS', '4', 'C', 'TELECOM', 'joanmart', 'test', 'Offline'),
('10-0043', 'Pelones', 'Lorielyn', 'Ollera', 'CS', '4', 'C', 'TELECOM', '123', 'test', 'Offline'),
('09-3421', 'Regine', 'Emanel', '', 'CS', '4', 'C', 'TELECOM', '1234', 'test', 'Offline'),
('11-2185', ' ', 'Benjamin', 'Flores', 'CS', '4', 'C', 'TELECOM', 'gboy123', 'test', 'Offline'),
('99-9999', 'monkey', 'luffy', 'Dragon', 'CS', '4', 'C', 'TELECOM', 'test', 'test', 'Offline'),
('11-1735', 'lorenzana', '      rdhdsger', '   ysrghkjaergMSEGoiEGsegjKKRbgmbrgjaehrgjabrmgdmfbmaerghHWBFJERGNB rkgJBAETHB', 'CS', '4', 'C', 'TELECOM', '1234', 'test', 'Offline'),
('13-0000', 'last', 'first', 'middle', 'CS', '4', 'C', 'TELECOM', 'a', 'test', 'Offline'),
('11-2461', 'tkaskod', 'asjd', 'sdf', 'CS', '4', 'C', 'TELECOM', '902139', 'test', 'Offline'),
('09-1317', 'arante', 'nikko', '', 'CS', '4', 'C', 'TELECOM', '12345', 'test', 'Offline'),
('11-1111', 'yanasd', 'aasd', 'd', 'CS', '4', 'C', 'TELECOM', '1234', 'test', 'Offline'),
('12-0087', 'hjggghjh', 'hjh', 'hgbhgjjjjjj', 'CS', '4', 'C', 'TELECOM', 'z', 'test', 'Offline'),
('09-0909', 'Nene', 'Nono', 'Nini', 'CS', '4', 'C', 'TELECOM', '1234', 'test', 'Online'),
('09-3612', 'Bucalan', 'Cynthia', 'Branzuela', 'CS', '4', 'C', 'TELECOM', 'dearest', 'test', 'Offline'),
('09-3613', 'cadungog', 'ian', 'cab', 'CS', '4', 'C', 'TELECOM', 'dearest', 'test', 'Offline'),
('09-3421', 'Emaenl', 'Regine', '', 'CS', '4', 'C', 'ASP', '1234', 'jeanel', 'Offline'),
('10-1168', 'masbang', 'jeanel', 'martirez', 'CS', '4', 'C', 'ASP', 'jeanel', 'jeanel', 'Offline'),
('10-0301', 'balladares', 'judie', 'insag', 'CS', '4', 'C', 'ASP', 'judie', 'jeanel', 'Offline'),
('10-1123', 'masbang', 'jeanel', 'martirez', 'CS', '4', 'C', 'ASP', 'masbang', 'jeanel', 'Online'),
('10-0380', 'abrenica', 'joshua', '', 'CS', '4', 'C', 'ASP', '1234', 'jeanel', 'Online'),
('10-0302', 'ambrocio', 'cheryl', '', 'CS', '4', 'C', 'ASP', 'judz', 'jeanel', 'Online'),
('10-1234', 'masbang', 'jeanel', 'martirez', 'CS', '4', 'C', 'ASP', 'jel', 'jeanel', 'Offline'),
('09-3422', 'regine', 'emanel', '', 'CS', '4', 'C', 'ASP', '1234', 'jeanel', 'Offline'),
('10-2299', 'Yap', 'Mary Grace', 'Saldavia', 'CS', '4', 'C', 'ASP', 'Steele', 'jeanel', 'Online'),
('09-3423', 'emanel', 'regine', '', 'CS', '4', 'C', 'ASP', '0987', 'jeanel', 'Offline'),
('10-0043', 'Pelones', 'Lorielyn', 'Ollera', 'CS', '4', 'C', 'ASP', '111', 'jeanel', 'Offline'),
('10-0240', 'Yumang', 'Ma Joy', 'Doctor', 'CS', '4', 'C', 'ASP', '0028', 'jeanel', 'Offline'),
('10-0001', 'Balladares', 'Judiiiiiiie', 'Baliw', 'CS', '4', 'C', 'ASP', '0000', 'jeanel', 'Online'),
('10-0181', 'sotto', 'jessica mae', 'clements', 'CS', '4', 'c', 'graphics design', 'sotto', 'joan', 'Online'),
('09-3421', 'emanel', 'regine', 'galiste', 'CS', '4', 'c', 'graphics design', '1234', 'joan', 'Offline'),
('10-0043', 'Pelones', 'Lorielyn', 'Ollera', 'CS', '4', 'c', 'graphics design', '123', 'joan', 'Offline'),
('10-0240', 'Yumang', 'Ma Joy', 'Doctor', 'CS', '4', 'c', 'graphics design', 'joijoi', 'joan', 'Offline'),
('10-1103', 'lachica', 'joan', '', 'CS', '4', 'c', 'graphics design', 'joanmart', 'joan', 'Offline'),
('10-0182', 'sotto', 'jessica mae', 'clements', 'CS', '4', 'c', 'graphics design', 'sotto', 'joan', 'Offline'),
('11-0987', 'Hernandez', 'Roshy Mae', 'Espinosa', 'CS', '4', 'c', 'graphics design', 'QWEQWE', 'joan', 'Offline'),
('11-1715', 'Donato', 'Fatima', 'Dela Cruz', 'CS', '4', 'c', 'graphics design', 'fatima', 'joan', 'Offline'),
('12-3184', 'pugahan', 'jacquelyn', 'noble', 'CS', '4', 'c', 'graphics design', 'captain', 'joan', 'Offline'),
('12-2104', 'jacinto', 'danielle', 'payumo', 'CS', '4', 'c', 'graphics design', 'pasaway', 'joan', 'Offline'),
('11-1548', 'camacho', 'sonny boy', 'aventura', 'CS', '4', 'c', 'graphics design', 'camacho', 'joan', 'Offline'),
('10-0301', 'balladares', 'judie', 'insag', 'CS', '4', 'c', 'graphics design', 'judie', 'joan', 'Offline'),
('10-0576', 'barca', 'carlo jay', 'caceres', 'CS', '4', 'c', 'graphics design', 'barca', 'joan', 'Online'),
('12-1305', 'aquino', 'eimireen', 'reyes', 'CS', '4', 'c', 'graphics design', '12345', 'joan', 'Offline'),
('12-1419', 'Hipolito', 'Angelica Chastene', 'Manuel', 'CS', '4', 'c', 'graphics design', 'chastene', 'joan', 'Offline'),
('10-0938', 'dela torre', 'joseph', 'lodivico', 'CS', '4', 'c', 'graphics design', '123456', 'joan', 'Offline'),
('10-9754', 'Hernandez', 'Mark Lucio', 'Brion', 'CS', '4', 'c', 'graphics design', 'mark', 'joan', 'Offline'),
('12-1466', 'tiberio', 'nina', '', 'CS', '4', 'c', 'graphics design', 'nyang', 'joan', 'Offline'),
('12-3193', 'tamayo', 'carol', 'arnecilla', 'CS', '4', 'c', 'graphics design', 'jesus', 'joan', 'Offline'),
('09-3424', 'emanel', 'regine', '', 'CS', '4', 'c', 'graphics design', '1234', 'joan', 'Offline'),
('10-0282', 'cabangbang', 'fe', 'josol', 'CS', '4', 'c', 'graphics design', 'fengfeng', 'joan', 'Offline'),
('10-0839', 'dionela', 'jethro', 'tejeresas', 'CS', '4', 'c', 'graphics design', 'yeyebonel', 'joan', 'Offline'),
('11-1850', 'caparas', 'diana rose', 'gutierrez', 'CS', '4', 'c', 'graphics design', 'diane', 'joan', 'Offline'),
('10-1624', 'Yaon Jr', 'Alejandro', 'S', 'CS', '4', 'c', 'graphics design', 'yaon', 'joan', 'Offline'),
('11-0968', 'Mondia', 'Nickle', 'Roleda', 'CS', '4', 'c', 'graphics design', 'm3rrick', 'joan', 'Offline'),
('11-1212', 'Martin', 'Jerome', 'Evangelista', 'CS', '4', 'c', 'graphics design', 'asdfghjkl', 'joan', 'Offline'),
('10-1352', 'tolentino', 'kristine', 'De Guzman', 'CS', '4', 'c', 'graphics design', 'tintin', 'joan', 'Offline'),
('10-0095', 'Usacdin', 'Melmar', 'Refil', 'CS', '4', 'c', 'graphics design', 'melmar', 'joan', 'Offline'),
('10-0258', 'domingo', 'janine', 'elfante', 'CS', '4', 'c', 'graphics design', '12345', 'joan', 'Offline'),
('10-0816', 'duazo', 'annie', 'yleana', 'CS', '4', 'c', 'graphics design', '130ss5nn', 'joan', 'Offline'),
('10-7876', 'sample', 'sample', 'sample', 'CS', '4', 'c', 'graphics design', '123', 'joan', 'Offline'),
('11-1345', 'reyes', 'jerson', 'cornejo', 'CS', '4', 'c', 'graphics design', '12345', 'joan', 'Offline'),
('10-2795', 'Loria', 'Sharlyn Theresa', 'Lazado', 'CS', '4', 'c', 'graphics design', 'NAM', 'joan', 'Offline'),
('11-2236', 'labing-isa', 'aaron', 'moreno', 'CS', '4', 'c', 'graphics design', '123123', 'joan', 'Online'),
('11-1504', 'quenangan', 'ron', 'Fulugan', 'CS', '4', 'c', 'graphics design', 'ronron', 'joan', 'Online'),
('09-3421', 'Emanel', 'Regine', '', 'CS', '4', 'B', 'TELECOM', '0987', 'joan', 'Offline'),
('10-3456', 'dares', 'judz', 'vidad', 'CS', '4', 'B', 'TELECOM', 'judz', 'joan', 'Offline'),
('10-1103', 'lachica', 'joan', '', 'CS', '4', 'B', 'TELECOM', 'joanmart', 'joan', 'Offline'),
('10-0043', 'Pelones', 'Lorielyn', 'Ollera', 'CS', '4', 'B', 'TELECOM', '123', 'joan', 'Offline'),
('10-9876', 'jauculan', 'jela', 'balladares', 'CS', '4', 'B', 'TELECOM', 'jela', 'rheyan', 'Online'),
('10-0240', 'Yumang', 'Ma Joy', 'Doctor', 'CS', '4', 'B', 'TELECOM', '123', 'rheyan', 'Online'),
('10-1103', 'lachica', 'joan', '', 'CS', '4', 'C', 'TELECOM', 'joanmart', 'joanmart5711', 'Online'),
('10-4321', 'balladares', 'judie', 'insag', 'CS', '4', 'C', 'TELECOM', 'judie', 'joanmart5711', 'Online'),
('10-0301', 'balladares', 'ma judie', 'insag', '', '4', 'C', 'java', 'judie', 'joanjoan', 'Offline'),
('10-0240', 'Yumang', 'Ma Joy', 'Doctor', '', '4', 'C', 'java', '0000', 'joanjoan', 'Online'),
('11-1548', 'camacho', 'sonny boy', 'aventura', '', '4', 'C', 'java', 'camacho', 'joanjoan', 'Offline');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_timer`
--

CREATE TABLE IF NOT EXISTS `tbl_timer` (
  `computername` varchar(100) NOT NULL,
  `ipaddress` varchar(100) NOT NULL,
  `pcin` varchar(50) NOT NULL,
  `pcsec` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  PRIMARY KEY (`computername`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_word`
--

CREATE TABLE IF NOT EXISTS `tbl_word` (
  `wordcall` varchar(100) NOT NULL,
  `toprint` varchar(255) NOT NULL,
  `avail` varchar(255) NOT NULL,
  `accountuser` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_word`
--

INSERT INTO `tbl_word` (`wordcall`, `toprint`, `avail`, `accountuser`) VALUES
('begin', '<', 'HTML', 'System'),
('end', '</', 'HTML', 'System'),
('html', 'HTML>', 'HTML', 'System'),
('body', 'BODY>', 'HTML', 'System'),
('head', 'HEAD>', 'HTML', 'System'),
('title', 'TITLE>', 'HTML', 'System'),
('messagebox', 'Messagebox', 'Visual-Basic', 'System'),
('dot', '.', 'Visual-Basic', 'System'),
('show', 'Show{(}{)}', 'Visual-Basic', 'System');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_wordtype`
--

CREATE TABLE IF NOT EXISTS `tbl_wordtype` (
  `wordtype` varchar(255) NOT NULL,
  `accountuser` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_wordtype`
--

INSERT INTO `tbl_wordtype` (`wordtype`, `accountuser`) VALUES
('Visual-Basic', 'System'),
('HTML', 'System');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
