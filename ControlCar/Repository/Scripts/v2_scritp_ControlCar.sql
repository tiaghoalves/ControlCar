use ControlCar;

drop table Scheduling;
drop table VehicleMaintenance;
drop table Vehicle;
drop table StatusVehicle;
drop table StatusScheduling;
drop table [Authentication];
drop table Maintenance;
drop table [Route];
drop table Driver;

--
-- Driver
--
create table Driver(
   IdDriver                int IDENTITY(1,1) not null -- Driver identifier
  ,Name                        varchar(25)   not null -- Registered Driver Name
  ,Cpf                         varchar(11)   not null -- CPF of the registered Driver
  ,ExpirationDateCnh         datetime      not null -- expiration date of CNH Driver
  ,Office                       varchar(10)       null -- Registered Driver's Office
  ,Address                    varchar(30)       null -- Driver Address
  ,Cellphone                     varchar(11)       null -- Driver Cellphone Number
  ,TypeDriver              varchar(10)       null -- Driver type, car, van
  ,BirthDate             datetime          null -- Driver's date of birth
  ,Sector                       varchar(10)       null -- Sector in which the Driver works
  ,Rg                          numeric(10)   not null -- Driver RG number
  ,constraint pk_Driver primary key nonclustered (idDriver)
);


--
-- Route
--
create table Route(
   IdRoute                          int   IDENTITY(1,1)        not null -- Route Identifier
  ,Source                           varchar(50)       null -- Route's city of origin
  ,Destiny                          varchar(50)       null -- Route destination city
  ,KmPattern                        float             null -- Default Distance to Route
  ,constraint pk_Route primary key nonclustered (idRoute)
);

--
-- MAINTENANCE
--
create table Maintenance(
   IdMaintenance       int    IDENTITY(1,1)      not null -- Maintenance identifier
  ,[Description]           varchar(100) not null -- Maintenance Description
  ,Frequency       datetime      not null -- Time interval for each Maintenance
  ,constraint pk_maintenance primary key nonclustered (idmaintenance)
);


--
-- AUTHENTICATION
--
create table Authentication(
   IdAuthentication      int    IDENTITY(1,1)       not null -- Authentication identifier
  ,[User]                 varchar(100)  not null -- Admin User Name
  ,Email                varchar(100)  not null -- Admin user email address
  ,[Password]                varchar(100)  not null -- Admin user password
  ,constraint pk_autentication primary key nonclustered (IdAuthentication)
);

--
-- STATUS Scheduling
--
create table StatusScheduling(
   IdstatusScheduling        int   IDENTITY(1,1)       not null  -- Scheduling status identifier
  ,Description                    varchar(100) not null  -- Scheduling Status
  ,constraint pk_status_Scheduling primary key nonclustered (idstatusscheduling)
);

--
-- STATUS VEÍCULO
--
create table StatusVehicle(
   IdstatusVehicle    int    IDENTITY(1,1)      not null  -- Vehicle Status Identifier
  ,Description            varchar(100) not null  -- Vehicle status
  ,constraint pk_status_vehicle primary key nonclustered (idstatusvehicle)
);

--
-- Vehicles
--
create table Vehicle(
   IdVehicle            int  IDENTITY(1,1)         not null -- Vehicle identifier
  ,Model                varchar(10)       null -- Vehicle Model
  ,Km                    float         not null -- Current vehicle mileage
  ,Board                 varchar(20)   not null -- Vehicle license board identification
  ,Type                  varchar(10)       null -- Vehicle Type Identification
  ,Brand                 varchar(10)       null -- Vehicle model description
  ,Color                 varchar(100)      null -- Vehicle color description
  ,Year                  datetime      not null -- Year of manufacture of the vehicle
  ,Renavam               numeric       not null -- Vehicle document number
  ,Chassi                numeric       not null -- Chassi Marking Number
  ,IdStatusVehicle       int               null -- Vehicle Status Identification
  ,Observation            varchar(300)  not null -- Vehicle observation
  ,constraint pk_Vehicle primary key nonclustered (idVehicle)
  , constraint fk_Vehicle_statusVehicle foreign key (idstatusVehicle)
    references StatusVehicle (idstatusVehicle)
    on delete cascade
    on update cascade
);

--
-- VEHICLE MAINTENANCE
--
create table VehicleMaintenance(
   IdVehicleMaintenance    int    IDENTITY(1,1)      not null   -- Maintenance Vehicle Identifier
  ,IdVehicle               int          not null   -- Vehicle identifier
  ,IdMaintenance           int           not null   -- Maintenance identifier
  ,DateMaintenance          datetime   not null   -- Date Maintenance 
  ,constraint pk_veicmanu primary key nonclustered (idVehiclemaintenance)
  , constraint fk_veicmanu_maintenance foreign key (idmaintenance)
    references maintenance (idmaintenance)
  on update no action 
  on delete no action
  , constraint fk_veicmanu_Vehicle foreign key (idVehicle)
    references Vehicle (idVehicle)
  on update no action 
  on delete no action
);

--
-- SchedulingS
--
create table Scheduling(
   IdScheduling             int   IDENTITY(1,1)     not null -- Scheduling identifier
  ,ExpectedStartDate      datetime   not null -- Scheduled Scheduling Start Date
  ,ExpectedEndDate        datetime   not null -- Scheduled Scheduling End Date
  ,IdRoute                    int            null -- Route identification
  ,IdVehicle                 int            null -- Vehicle identification
  ,IdDriver               int            null -- Driver Identification
  ,StartDatePerformed     datetime       null -- Start Date of Scheduling Performed
  ,EndDatePerformed       datetime       null -- End date of appointment made
  ,EndKm                   float          null -- Mileage covered identification
  ,IdStatusScheduling      int            null -- Status identification, ending in
  ,IdAuthentication           int            null -- Authentication identification
  ,constraint pk_Scheduling primary key nonclustered (idScheduling)
  , constraint fk_Scheduling_Route foreign key (idRoute)
    references Route (idRoute)
    on delete cascade
    on update cascade
  , constraint fk_Scheduling_Vehicle foreign key (idVehicle)
    references Vehicle (idVehicle)
    on delete cascade
    on update cascade
  , constraint fk_Scheduling_Driver foreign key (idDriver)
    references Driver (idDriver)
    on delete cascade
    on update cascade
  , constraint fk_Scheduling_status_Scheduling foreign key (idstatusScheduling)
    references StatusScheduling (idstatusScheduling)
    on delete cascade
    on update cascade
  , constraint fk_Scheduling_authentication foreign key (idScheduling)
    references Authentication (idAuthentication)
    on delete cascade
    on update cascade
);

                                               
INSERT INTO [Driver]
           ([Name]
           ,[cpf]
           ,[ExpirationDatecnh]
           ,[Office]
           ,[Address]
           ,[Cellphone]
           ,[TypeDriver]
           ,[BirthDate]
           ,[Sector]
           ,[rg])
     VALUES
           ('MARIANA'
           ,'00000000001'
           ,'20220618 10:34:09'
           ,'SUPERVISOR'
           ,'RUA 123'
           ,'05491921555'
           ,'CARRO'
           ,'19900415 10:34:09'
           ,'FRoute'
           ,9000000009
       )
--
INSERT INTO [Driver]
           ([Name]
           ,[cpf]
           ,[ExpirationDatecnh]
           ,[Office]
           ,[Address]
           ,[Cellphone]
           ,[TypeDriver]
           ,[BirthDate]
           ,[Sector]
           ,[rg])
     VALUES
           ('IVAN'
           ,'00000000002'
           ,'20250211 07:02:09'
           ,'CONDUTOR'
           ,'RUA TESTE'
           ,'05195342828'
           ,'VAN'
           ,'19860112 18:31:09'
           ,'FRoute'
           ,8000000008
       )
--
INSERT INTO [Route]
           ([source]
           ,[destiny]
           ,KmPattern)
     VALUES
           ('CAXIAS DO SUL'
           ,'BENTO GONCALVES'
           ,44)
--
INSERT INTO [Route]
           ([idRoute]
           ,[source]
           ,[destiny]
           ,[KmPattern])
     VALUES
           ('CAXIAS DO SUL'
           ,'FARROUPILHA'
           ,18.7)
--
INSERT INTO [Route]
           ([source]
           ,[destiny]
           ,[KmPattern])
     VALUES
           ('CAXIAS DO SUL'
           ,'FLORES DA CUNHA'
           ,19.8)
--
INSERT INTO [maintenance]
           ([description]
           ,[frequency])
     VALUES
           ('TROCA DE OLEO'
           ,'20220112 18:31:09')
--
INSERT INTO [maintenance]
           ([description]
           ,[frequency])
     VALUES
           ('CORREIA DO PONTO'
           ,'20220305 07:00:01')
--
INSERT INTO [maintenance]
           ([description]
           ,[frequency])
     VALUES
           ('PASTILHAS DE FREIO'
           ,'20211212 09:02:01')
--
INSERT INTO [Authentication]
           ([User]
           ,[email]
           ,[Password])
     VALUES
           ('MARIANA.PEZZI'
           ,'MARIANA.PEZZI@GMAIL.COM'
           ,'MPEZZI')
--
INSERT INTO [authentication]
           ([user]
           ,[email]
           ,[password])
     VALUES
           (200
           ,'IVAN.OLIVEIRA'
           ,'IVAN.OLIVEIRA@GMAIL.COM'
           ,'IOLIVEIRA')
--
INSERT INTO [statusScheduling]
           ([idstatusScheduling]
           ,[description])
     VALUES
           (1000
           ,'AGUARDANDO')
--
INSERT INTO [statusScheduling]
           ([idstatusScheduling]
           ,[description])
     VALUES
           (2000
           ,'INICIADO')
--
INSERT INTO [statusScheduling]
           ([idstatusScheduling]
           ,[description])
     VALUES
           (3000
           ,'FINALIZADO')
--
INSERT INTO [statusVehicle]
           ([idstatusVehicle]
           ,[description])
     VALUES
           (2
           ,'INATIVO')
--
INSERT INTO [statusVehicle]
           ([idstatusVehicle]
           ,[description])
     VALUES
           (1
           ,'ATIVO')
--

INSERT INTO [Vehicle]
           ([idVehicle]
           ,[model]
           ,[km]
           ,[board]
           ,[Type]
           ,[Model]
           ,[Color]
           ,[Year]
           ,[renavam]
           ,[chassi]
           --,[idmaintenance]
           ,[idstatusVehicle]
           ,[Observation])
     VALUES
           (11
           ,'UNO'
           ,11000
           ,'IQU-2015'
           ,''
           ,''
           ,'BRANCO'
           ,'20211212 09:02:01'
           ,123456
           ,654321
           --,<idmaintenance, int,>
           ,1
           ,'OBS')
--
INSERT INTO [Vehicle]
           ([idVehicle]
           ,[model]
           ,[km]
           ,[board]
           ,[Type]
           ,[Model]
           ,[Color]
           ,[Year]
           ,[renavam]
           ,[chassi]
           --,[idmaintenance]
           ,[idstatusVehicle]
           ,[Observation])
     VALUES
           (12
           ,'ONIBUS'
           ,5000
           ,'IQA-2022'
           ,''
           ,'MARCOPOLO'
           ,'AZUL'
           ,'20001212 09:02:01'
           ,987456
           ,654789
           --,<idmaintenance, int,>
           ,1
           ,'TESTE')
--
INSERT INTO [Vehicle]
           ([idVehicle]
           ,[Model]
           ,[km]
           ,[board]
           ,[type]
           ,[Brand]
           ,[Color]
           ,[Year]
           ,[renavam]
           ,[chassi]
           --,[idmaintenance]
           ,[idstatusVehicle]
           ,[observation])
     VALUES
           (13
           ,'KOMBI'
           ,100
           ,'IED-1825'
           ,''
           ,''
           ,''
           ,'20011212 09:02:01'
           ,147852
           ,698547
           --,<idmaintenance, int,>
           ,2
           ,'INATIVADO')
--

INSERT INTO [Vehiclemaintenance]
           ([idVehiclemaintenance]
           ,[idVehicle]
           ,[idmaintenance]
           ,[DateMaintenance])
     VALUES
           (1
           ,11
           ,10
           ,'20201112 09:02:01')
--
INSERT INTO [Vehiclemaintenance]
           ([idVehiclemaintenance]
           ,[idVehicle]
           ,[idmaintenance]
           ,[DateMaintenance])
     VALUES
           (6
           ,11
           ,10
           ,'20201213 09:02:01')
--
INSERT INTO [Vehiclemaintenance]
           ([idVehiclemaintenance]
           ,[idVehicle]
           ,[idmaintenance]
           ,DateMaintenance)
     VALUES
           (2
           ,11
           ,20
           ,'20201112 10:15:30')
--
INSERT INTO [Vehiclemaintenance]
           ([idVehiclemaintenance]
           ,[idVehicle]
           ,[idmaintenance]
           ,[DateMaintenance])
     VALUES
           (3
           ,11
           ,30
           ,'20201212 11:30:00')
--
INSERT INTO [Vehiclemaintenance]
           ([idVehiclemaintenance]
           ,[idVehicle]
           ,[idmaintenance]
           ,DateMaintenance)
     VALUES
           (4
           ,12
           ,20
           ,'20201226 10:00:12')
--
INSERT INTO [Vehiclemaintenance]
           ([idVehiclemaintenance]
           ,[idVehicle]
           ,[idmaintenance]
           ,DateMaintenance)
     VALUES
           (5
           ,12
           ,30
           ,'20201215 08:20:00')
--
INSERT INTO [Scheduling]
           ([idScheduling]
           ,[expectedstartdate]
           ,[expectedenddate]
           ,[idRoute]
           ,[idVehicle]
           ,[idDriver]
           ,[startdateperformed]
           ,[enddateperformed]
           ,[endkm]
           ,[idstatusScheduling]
           ,[idauthentication])
     VALUES
           (1
           ,'20201112 09:02:01'
           ,'20201113 09:02:01'
           ,1
           ,11
           ,1
           ,'20201112 10:02:01'
           ,'20201113 11:02:01'
           ,11044
           ,2000
           ,200)
--
INSERT INTO [Scheduling]
           ([idScheduling]
           ,[expectedstartdate]
           ,[expectedenddate]
           ,[idRoute]
           ,[idVehicle]
           ,[idDriver]
           ,[startdateperformed]
           ,[enddateperformed]
           ,[endkm]
           ,[idstatusScheduling]
           ,[idauthentication])
     VALUES
           (2
           ,'20201113 07:20:01'
           ,'20201114 12:20:01'
           ,1
           ,11
           ,2
           ,'20201113 07:20:01'
           ,'20201115 07:10:00'
           ,11088
           ,1000
           ,200)
--
INSERT INTO [Scheduling]
           ([idScheduling]
           ,[expectedstartdate]
           ,[expectedenddate]
           ,[idRoute]
           ,[idVehicle]
           ,[idDriver]
           ,[startdateperformed]
           ,[enddateperformed]
           ,[endkm]
           ,[idstatusScheduling]
           ,IdAuthentication)
     VALUES
           (3
           ,'20201115 07:20:01'
           ,'20201116 12:20:01'
           ,2
           ,12
           ,1
           ,'20201115 07:20:01'
           ,'20201116 12:20:01'
           ,5018.7
           ,2000
           ,100);



