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
  StudentID int IDENTITY(1,1) PRIMARY KEY,
  Username 		varchar(50) NOT NULL, 
  Name 			varchar (50) 	NOT NULL,  
  Gender 		char (1) 	NOT NULL CHECK (Gender IN ('M', 'F')),  
  DOB			DATE 	NOT NULL CHECK (datediff(yy, DOB, GETDATE()) >= 16),  
  Password		varchar(50)	NOT NULL, 
  Email varchar(255) UNIQUE, 
  CONSTRAINT CHK_Staff_Gender CHECK (Gender IN ('M', 'F')), 
  CHECK(Email LIKE '%@%.%' AND Email NOT LIKE '@%' AND Email NOT LIKE '%@%@%') 
) 
CREATE TABLE dbo.Points
(
  Point		int,
  StudentID		int,    
  CONSTRAINT PK_Points Primary KEY (StudentID),
  CONSTRAINT Fk_Points_Student FOREIGN KEY(StudentID) REFERENCES Student(StudentID)
) 
GO 
CREATE TABLE dbo.Canteen 
( 
  CanteenID INT IDENTITY(1,1) PRIMARY KEY,  
  Name 			varchar (50) 	NOT NULL,  
  Location		varchar(50) NOT NULL 
) 
GO 
CREATE TABLE dbo.Vendor   
( 
  VendorID 		int 	IDENTITY(1,1)	PRIMARY KEY,  
  Username varchar(50) NOT NULL,
  StallName 			varchar (50) 	NOT NULL,  
  Password		varchar(50)	NOT NULL,  
  CanteenID		int			NOT NULL,    
  CONSTRAINT FK_Vendor_CanteenID FOREIGN KEY (CanteenID)   
  REFERENCES dbo.Canteen(CanteenID),  
)  
GO  
CREATE TABLE dbo.Store   
(  
  StoreID 		INT IDENTITY(1,1) PRIMARY KEY,  
  VendorID		int				NOT NULL,  
  Name 			varchar (50) 	NOT NULL,  
  CONSTRAINT FK_Store_VendorID FOREIGN KEY (VendorID)   
  REFERENCES dbo.Vendor(VendorID),  
)  
GO  
CREATE TABLE dbo.Food 
(  
  FoodID 		int IDENTITY(1,1) PRIMARY KEY,  
  StoreID		int				NOT NULL,  
  Name 			varchar (50) 	NOT NULL,   
  CONSTRAINT FK_Food_StoreID FOREIGN KEY (StoreID)   
  REFERENCES dbo.Store(StoreID),  
)  
GO 

CREATE TABLE dbo.Ordered
(
  OrderID		int IDENTITY(1,1) PRIMARY KEY,
  StudentID		int				NOT NULL,
  StoreID		int				NOT NULL,
  OrderDateTime smalldatetime	NOT NULL,

  CONSTRAINT FK_Order_StudentID FOREIGN KEY (StudentID) REFERENCES dbo.Student(StudentID), 
  CONSTRAINT FK_Order_StoreID FOREIGN KEY (StoreID) REFERENCES dbo.Store(StoreID),
)
GO

CREATE TABLE dbo.OrderDetails
(
  OrderDetailId	int IDENTITY(1,1) PRIMARY KEY,
  OrderID		int				NOT NULL,
  FoodID 		int				NOT NULL,
  SpecialRequest	varchar(50),
  OrderQty		int				NOT NULL,

  CONSTRAINT FK_OrderDetails_OrderID FOREIGN KEY (OrderID) REFERENCES dbo.Ordered(OrderID), 
  CONSTRAINT FK_Orderhistory_FoodID FOREIGN KEY (FoodID) REFERENCES dbo.Food(FoodID), 
)  
GO 

/*Inserting values into*/ 
/*Inserting values into student*/ 
insert into Student (Username,Name,Gender,DOB,Password,Email) values ('S10203927J','Low Hong Wei','M','31-July-2003',' ', 'LowHongWei2003@gmail.com')  
insert into Student (Username,Name,Gender,DOB,Password,Email) values ('s','Low Hong Wefi','M','31-July-2003',' ', 'LowHongWei2d003@gmail.com')  
insert into Student (Username,Name,Gender,DOB,Password,Email) values ('L','Jeff','M','31-July-2003',' ', 'Jeff@gmail.com')  

/*Inserting values into points*/ 
insert into Points (StudentID,Point) values (1,69)  
insert into Points (StudentID,Point) values (2,69)    
/*Inserting values into Canteen*/  
insert into Canteen(Name,Location) values('Food Club', 'Blk 22')  
insert into Canteen(Name,Location) values('Makan Place', 'Blk 51')  
insert into Canteen(Name,Location) values('Munch', 'Blk 73')  
/*Inserting values into Vendors*/  
insert into Vendor(Username,StallName,Password,CanteenID) values ('VCR','Big Boss Chicken Rice', 'BossChicken123', 1)  
insert into Vendor(Username,StallName,Password,CanteenID) values ('VSB', 'Salad Bar', 'YOYOBARYOYOSALAD',1)  
insert into Vendor(Username,StallName,Password,CanteenID) values('VNGOGO', 'Nasi GOGO', 'IGOGONASI',1)  
insert into Vendor(Username,StallName,Password,CanteenID) values ('VS', 'Subway', 'SubwayStation123',2)  
insert into Vendor(Username,StallName,Password,CanteenID) values('VMDL', 'Mala DAMN LA', 'BLALALALA',2)  
insert into Vendor(Username,StallName,Password,CanteenID) values ('VWP', 'Western PHOOD', 'BiscuitsAndGravy',3)  
insert into Vendor(Username,StallName,Password,CanteenID) values('VYTF', 'Yong Tau Foo', 'YouAreAFoo',3)  
/*Inserting values into Store*/  
insert into Store values (1, 'Big Boss Chicken Rice')  
insert into Store values (2,'Salad Bar')  
insert into Store values (3,'Nasi GOGO')  
insert into Store values (4, 'Subway')  
insert into Store values (5, 'Mala DAMN LA')  
insert into Store values (6, 'Western PHOOD')  
insert into Store values (7, 'Yong Tau Foo')  
/*Inserting values into Food*/  
insert into Food values (1, 'Lemon chicken rice')  
insert into Food values (1, 'Roasted chicken rice')  
insert into Food values (2, 'Potato salad')  
insert into Food values (3, 'Ayam penyet')  
insert into Food values (3, 'Nasi Lemak')  
insert into Food values (4, 'Subwaymelt')  
insert into Food values (5, 'Malala')  
insert into Food values (6, 'Chicken chop')  
insert into Food values (7, 'Nani potato')  

/*Inserting values into Orderhistory*/  


Select * from Student  
Select * from Points
Select * from Vendor  
Select * from Canteen  
Select * from Vendor  
Select * from Store  
Select * from Food
Select * from Ordered
Select * from OrderDetails