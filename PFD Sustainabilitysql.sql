/*** Delete database if it exists ***/  

  

USE master  

  

IF EXISTS(select * from sys.databases where name='SustainabilityPFD')  

  

DROP DATABASE SustainabilityPFD  

  

GO  

  

   

  

Create Database SustainabilityPFD  

  

GO  

  

   

  

use SustainabilityPFD  

  

GO  

  

   

  

/*** Delete tables (if they exist) before creating ***/  

  

   

  

/* Table: dbo.User */  

  

if exists (select * from sysobjects   

  

  where id = object_id('dbo.User') and sysstat & 0xf = 3)  

  

  drop table dbo.Student  

  

GO  

  

   

  

/*** Delete tables (if they exist) before creating ***/  

  

   

  

/* Table: dbo.Vendor */  

  

if exists (select * from sysobjects   

  

  where id = object_id('dbo.Vendor') and sysstat & 0xf = 3)  

  

  drop table dbo.Vendor  

  

GO  

  

   

  

/*** Delete tables (if they exist) before creating ***/  

  

   

  

/* Table: dbo.Canteen */  

  

if exists (select * from sysobjects   

  

  where id = object_id('dbo.Canteen') and sysstat & 0xf = 3)  

  

  drop table dbo.Canteen  

  

GO  

  

   

  

CREATE TABLE dbo.Student   

  

(  

  

  StudentID 		varchar(50),  

  

  Name 			varchar (50) 	NOT NULL,  

  

  Gender 		char (1) 	NOT NULL CHECK (Gender IN ('M', 'F')),  

  

  DOB			smalldatetime 	NOT NULL CHECK (datediff(yy, DOB, GETDATE()) >= 16),  

  

  Password		varchar(50)	NOT NULL,  

  Email varchar(255) UNIQUE, 

  

  CONSTRAINT PK_Student PRIMARY KEY NONCLUSTERED (StudentID),  

  

  CONSTRAINT CHK_Staff_Gender CHECK (Gender IN ('M', 'F')), 

  CHECK(Email LIKE '%@%.%' AND Email NOT LIKE '@%' AND Email NOT LIKE '%@%@%') 

  

)  

  

GO  

  

   

  

CREATE TABLE dbo.Canteen  

  

(  

  

  CanteenID 		int,  

  

  Name 			varchar (50) 	NOT NULL,  

  

  Location		varchar(50) NOT NULL,  

  

  CONSTRAINT PK_Canteen PRIMARY KEY NONCLUSTERED (CanteenID),  

  

)  

  

GO  

  

   

  

CREATE TABLE dbo.Vendor   

  

(  

  

  VendorID 		int 		NOT NULL,  

  

  Name 			varchar (50) 	NOT NULL,  

  

  Password		varchar(50)	NOT NULL,  

  

  CanteenID		int			NOT NULL,  

  

  CONSTRAINT PK_Vendor PRIMARY KEY NONCLUSTERED (VendorID),  

  

  CONSTRAINT FK_Vendor_CanteenID FOREIGN KEY (CanteenID)   

  

  REFERENCES dbo.Canteen(CanteenID),  

  

)  

  

GO  

  

   

  

CREATE TABLE dbo.Store   

  

(  

  

  StoreID 		int,  

  

  VendorID		int				NOT NULL,  

  

  Name 			varchar (50) 	NOT NULL,  

  

  CONSTRAINT PK_Store PRIMARY KEY NONCLUSTERED (StoreID),  

  

  CONSTRAINT FK_Store_VendorID FOREIGN KEY (VendorID)   

  

  REFERENCES dbo.Vendor(VendorID),  

  

)  

  

GO  

  

   

  

CREATE TABLE dbo.Food   

  

(  

  

  FoodID 		int,  

  

  StoreID		int				NOT NULL,  

  

  Name 			varchar (50) 	NOT NULL,  

  

  CONSTRAINT PK_Food PRIMARY KEY NONCLUSTERED (FoodID, StoreID),  

  

  CONSTRAINT FK_Food_StoreID FOREIGN KEY (StoreID)   

  

  REFERENCES dbo.Store(StoreID),  

  

)  

  

GO  

  

   

  

/*Inserting values into*/  

  

   

  

/*Inserting values into student*/  

  

insert into Student values ('S10203927J','Low Hong Wei','M','31-July-2003',' ', 'LowHongWei2003@gmail.com')  

insert into Student values ('s','Low Hong Wefi','M','31-July-2003',' ', 'LowHongWei2d003@gmail.com')  

  

  

   

  

/*Inserting values into Canteen*/  

  

insert into Canteen values(1,'Food Club', 'Blk 22')  

  

insert into Canteen values(2,'Makan Place', 'Blk 51')  

  

insert into Canteen values(3,'Munch', 'Blk 73')  

  

   

  

/*Inserting values into Vendors*/  

  

insert into Vendor values (1,'Big Boss Chicken Rice', 'BossChicken123', 1)  

  

insert into Vendor values (2, 'Salad Bar', 'YOYOBARYOYOSALAD',1)  

  

insert into Vendor values(3, 'Nasi GOGO', 'IGOGONASI',1)  

  

insert into Vendor values (4, 'Subway', 'SubwayStation123',2)  

  

insert into Vendor values(5, 'Mala DAMN LA', 'BLALALALA',2)  

  

insert into Vendor values (6, 'Western PHOOD', 'BiscuitsAndGravy',3)  

  

insert into Vendor values(7, 'Yong Tau Foo', 'YouAreAFoo',3)  

  

   

  

/*Inserting values into Store*/  

  

insert into Store values (1, 1, 'Big Boss Chicken Rice')  

  

insert into Store values (2, 2, 'Salad Bar')  

  

insert into Store values (3, 3, 'Nasi GOGO')  

  

insert into Store values (4, 4, 'Subway')  

  

insert into Store values (5, 5, 'Mala DAMN LA')  

  

insert into Store values (6, 6, 'Western PHOOD')  

  

insert into Store values (7, 7, 'Yong Tau Foo')  

  

   

  

   

  

/*Inserting values into Food*/  

  

insert into Food values (1, 1, 'Lemon chicken rice')  

  

insert into Food values (2, 1, 'Roasted chicken rice')  

  

insert into Food values (1, 2, 'Potato salad')  

  

insert into Food values (1, 3, 'Ayam penyet')  

  

insert into Food values (1, 4, 'Subwaymelt')  

  

insert into Food values (1, 5, 'Malala')  

  

insert into Food values (1, 6, 'Chicken chop')  

  

insert into Food values (1, 7, 'Nani potato')  

  

   

  

Select * from Student  

  

Select * from Vendor  

  

Select * from Canteen  

  

Select * from Vendor  

  

Select * from Store  

  

Select * from Food 