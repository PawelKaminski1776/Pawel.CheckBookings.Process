-- Create the schema
CREATE SCHEMA IF NOT EXISTS dbo;

-- Drop existing tables if they exist
DROP TABLE IF EXISTS dbo.Admin CASCADE;
DROP TABLE IF EXISTS dbo.PigeonHoles CASCADE;
DROP TABLE IF EXISTS dbo.Bookings CASCADE;
DROP TABLE IF EXISTS dbo.Lanes CASCADE;

-- Create the Lanes table
CREATE TABLE dbo.Lanes (
  Lane_ID NUMERIC(2),
  Lane_Status CHAR(1) DEFAULT 'U',
  CONSTRAINT pk_Lane_ID PRIMARY KEY (Lane_ID)
);

-- Create the Bookings table
CREATE TABLE dbo.Bookings (
  Booking_ID NUMERIC(3),
  Forename VARCHAR(20) NOT NULL,
  Surname VARCHAR(30) NOT NULL,
  Booking_Date DATE NOT NULL,
  Booking_Time CHAR(2) NOT NULL,
  Booking_Status CHAR(1) DEFAULT 'B',
  NumOfShoes NUMERIC(1) NOT NULL,
  Booking_Cost NUMERIC(5,2) NOT NULL,
  Lane_ID NUMERIC(2),
  CONSTRAINT pk_Booking_ID PRIMARY KEY (Booking_ID),
  CONSTRAINT fk_Lane_ID FOREIGN KEY (Lane_ID) REFERENCES dbo.Lanes(Lane_ID) ON DELETE SET NULL
);

-- Create the PigeonHoles table
CREATE TABLE dbo.PigeonHoles (
  SlotNo NUMERIC(3),
  ShoeSize NUMERIC(2),
  BookingRef NUMERIC(3) DEFAULT NULL,
  CONSTRAINT pk_SlotNo PRIMARY KEY (SlotNo),
  CONSTRAINT fk_BookingRef FOREIGN KEY (BookingRef) REFERENCES dbo.Bookings(Booking_ID) ON DELETE SET NULL
);

-- Create the Admin table
CREATE TABLE dbo.Admin (
  Booking_Year NUMERIC(4) NOT NULL,
  Total_Bookings NUMERIC(5),
  Total_Revenue NUMERIC(10),
  CONSTRAINT pk_Booking_Year PRIMARY KEY(Booking_Year)
);
