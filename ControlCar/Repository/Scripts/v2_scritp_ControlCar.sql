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
  ,Cpf                         varchar(38)   not null -- CPF of the registered Driver
  ,ExpirationDateCnh         datetime      not null -- expiration date of CNH Driver
  ,Office                       varchar(38)       null -- Registered Driver's Office
  ,Address                    varchar(50)       null -- Driver Address
  ,Cellphone                     varchar(38)       null -- Driver Cellphone Number
  ,TypeDriver              varchar(38)       null -- Driver type, car, van
  ,BirthDate             datetime          null -- Driver's date of birth
  ,Sector                       varchar(38)       null -- Sector in which the Driver works
  ,Rg                          numeric(38)   not null -- Driver RG number
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
  ,IdAuthentication           int         not null -- Authentication identification
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
  , constraint fk_Scheduling_authentication foreign key (IdAuthentication)
    references Authentication (IdAuthentication)
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
           ([expectedstartdate]
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
           ('20201112 09:02:01'
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
           ([expectedstartdate]
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
           ('20201113 07:20:01'
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
           ([expectedstartdate]
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
           ('20201115 07:20:01'
           ,'20201116 12:20:01'
           ,2
           ,12
           ,1
           ,'20201115 07:20:01'
           ,'20201116 12:20:01'
           ,5018.7
           ,2000
           ,100);

alter table Vehicle DROP COLUMN Year;
alter table Vehicle add Year int not null;


INSERT INTO [dbo].[StatusVehicle]
           ([Description])
     VALUES
           ('ACTIVE');
GO

INSERT INTO [dbo].[StatusVehicle]
           ([Description])
     VALUES
           ('INACTIVE');
GO






-- Insere o usuário Administrador padrão
insert into [Authentication] ([User], Email, [Password]) values ('Administrador', 'admin@admin.com', 'Aa123');

-- Insere os status de agendamento disponíveis
insert into [StatusScheduling] ([Description]) values ('AGUARDANDO');
insert into [StatusScheduling] ([Description]) values ('INICIADO');
insert into [StatusScheduling] ([Description]) values ('FINALIZADO');

-- Insere Motoristas
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Miguel      ','92022631201','','Motorista','São Paulo	     ','05198540132','Freteiro','','Frota','2001628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Davi        ','92032631202','','Motorista','Rio de Janeiro','05198542026','Freteiro','','Frota','3002628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Arthur      ','92042631203','','Motorista','Salvador       ','05198542036','Freteiro','','Frota','4003628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Pedro       ','92052631204','','Motorista','Brasília       ','05198542046','Freteiro','','Frota','5004628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Gabriel     ','92062631205','','Motorista','Fortaleza       ','05198540532','Freteiro','','Frota','6005628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Bernardo    ','92072631206','','Motorista','Belo Horizonte','05198542066','Freteiro','','Frota','7006628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Lucas       ','92082631207','','Motorista','Manaus         ','05198542076','Freteiro','','Frota','8007628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Matheus     ','92092631208','','Motorista','Curitiba       ','05198542086','Freteiro','','Frota','9008628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Rafael      ','92102631209','','Motorista','Recife         ','05198542096','Freteiro','','Frota','0009628596');
INSERT INTO [dbo].[Driver]([Name],[Cpf],[ExpirationDateCnh],[Office],[Address],[Cellphone],[TypeDriver],[BirthDate],[Sector],[Rg]) VALUES('Heitor      ','92112631210','','Motorista','Porto Alegre   ','05198542106','Freteiro','','Frota','1010628596');

-- Insere veiculos
insert into [dbo].Vehicle (Model, km,  Board, Type, Brand,  Color, Year, Renavam,Chassi, IdStatusVehicle,Observation) values ( 'Gol'   ,  500, 'Volkswagen' , 'Hatch', '','Preto'    , 2010, 1231567, '113452789', 1, 'observação');
insert into [dbo].Vehicle (Model, km,  Board, Type, Brand,  Color, Year, Renavam,Chassi, IdStatusVehicle,Observation) values ( 'Palio'       ,  500, 'Fiat'       , 'Hatch', '','Branco'   , 2010, 1244567, '123453789', 1, 'observação');
insert into [dbo].Vehicle (Model, km,  Board, Type, Brand,  Color, Year, Renavam,Chassi, IdStatusVehicle,Observation) values ( 'Uno'         ,  500, 'Fiat'       , 'Hatch', '','Vermelho' , 2010, 2234567, '133454789', 1, 'observação');
insert into [dbo].Vehicle (Model, km,  Board, Type, Brand,  Color, Year, Renavam,Chassi, IdStatusVehicle,Observation) values ( 'Fiesta'      ,  500, 'Ford'       , 'Hatch', '','Azul'     , 2010, 1334567, '143455789', 1, 'observação');
insert into [dbo].Vehicle (Model, km,  Board, Type, Brand,  Color, Year, Renavam,Chassi, IdStatusVehicle,Observation) values ( 'Celta'  ,  500, 'Chevrolet'  , 'Hatch', '','Preto'    , 2010, 1235567, '153456789', 1, 'observação');

-- Insere rotas
insert into [dbo].Route (Source, Destiny, KmPattern) values ('São Paulo     ','Rio de Janeiro',01600);
insert into [dbo].Route (Source, Destiny, KmPattern) values ('Rio de Janeiro','Salvador      ',02600);
insert into [dbo].Route (Source, Destiny, KmPattern) values ('Salvador      ','Brasília      ',03600);
insert into [dbo].Route (Source, Destiny, KmPattern) values ('Brasília      ','Fortaleza     ',04600);
insert into [dbo].Route (Source, Destiny, KmPattern) values ('Fortaleza     ','Belo Horizonte',05600);
insert into [dbo].Route (Source, Destiny, KmPattern) values ('Belo Horizonte','Manaus        ',06600);
insert into [dbo].Route (Source, Destiny, KmPattern) values ('Manaus        ','Curitiba      ',07600);
