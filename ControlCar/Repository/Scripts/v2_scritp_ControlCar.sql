use ControlCar;

drop table Agendamento;
drop table VeiculoManutencao;
drop table Veiculo;
drop table StatusVeiculo;
drop table StatusAgendamento;
drop table Autenticacao;
drop table Manutencao;
drop table Rota;
drop table Motorista;

--
-- MOTORISTAS
--
create table Motorista (
   IdMotorista                int           not null -- Identificador do motorista
  ,Nome                        varchar(25)   not null -- Nome do motorista cadastrado
  ,Cpf                         varchar(11)   not null -- CPF do motorista cadastrado
  ,DataVencimentoCnh         datetime      not null -- Data de vencimento da CNH do motorista
  ,Cargo                       varchar(10)       null -- Cargo do motorista cadastrado
  ,Endereco                    varchar(30)       null -- Endereço do motorista
  ,Celular                     varchar(11)       null -- Número de celular do motorista
  ,TipoMotorista              varchar(10)       null -- Tipo de motorista, caro, van
  ,DataNascimento             datetime          null -- Data de nascimento do motorista
  ,Setor                       varchar(10)       null -- Setor em que o motorista trabalha
  ,Rg                          numeric(10)   not null -- Número do RG do motorista
  ,constraint pk_motorista primary key nonclustered (idmotorista)
);
exec sys.sp_addextendedproperty "ms_description", "Identificador do motorista (PK)", "user", "dbo", "table", "motorista", "column", "idmotorista"
exec sys.sp_addextendedproperty "ms_description", "Nome do motorista cadastrado", "user", "dbo", "table", "motorista", "column", "nome"
exec sys.sp_addextendedproperty "ms_description", "Cpf do motorista cadastrado", "user", "dbo", "table", "motorista", "column", "cpf"
exec sys.sp_addextendedproperty "ms_description", "Data de vencimento da cnh do motorista", "user", "dbo", "table", "motorista", "column", "datavencimentocnh"
exec sys.sp_addextendedproperty "ms_description", "Cargo do motorista cadastrado", "user", "dbo", "table", "motorista", "column", "cargo"
exec sys.sp_addextendedproperty "ms_description", "Endereço do motorista", "user", "dbo", "table", "motorista", "column", "endereco"
exec sys.sp_addextendedproperty "ms_description", "Número de celular do motorista", "user", "dbo", "table", "motorista", "column", "celular"
exec sys.sp_addextendedproperty "ms_description", "Tipo de motorista, caro, van", "user", "dbo", "table", "motorista", "column", "tipomotorista"
exec sys.sp_addextendedproperty "ms_description", "Data de nascimento do motorista", "user", "dbo", "table", "motorista", "column", "datanascimento"
exec sys.sp_addextendedproperty "ms_description", "Setor em que o motorista trabalha", "user", "dbo", "table", "motorista", "column", "setor"
exec sys.sp_addextendedproperty "ms_description", "Número do rg do motorista", "user", "dbo", "table", "motorista", "column", "rg"
--
-- ROTAS
--
create table Rota(
   IdRota                          int           not null -- Identificador da rota
  ,Origem                           varchar(50)       null -- Cidade de origem da rota
  ,Destino                          varchar(50)       null -- Cidade de destino da rota
  ,KmPadrao                        float             null -- Distância padrão para a rota
  ,constraint pk_rota primary key nonclustered (idrota)
);
exec sys.sp_addextendedproperty "ms_description", "Identificador da rota (PK)", "user", "dbo", "table", "rota", "column",        "idrota"
exec sys.sp_addextendedproperty "ms_description", "Cidade de origem da rota", "user", "dbo", "table", "rota", "column",     "origem"
exec sys.sp_addextendedproperty "ms_description", "Cidade de destino da rota", "user", "dbo", "table", "rota", "column",    "destino"
exec sys.sp_addextendedproperty "ms_description", "Distância padrão para a rota", "user", "dbo", "table", "rota", "column", "kmpadrao"
--
-- MANUTENÇÃO
--
create table Manutencao(
   IdManutencao       int          not null -- Identificador de manutenção
  ,Descricao           varchar(100) not null -- Descrição da manutenção
  ,Periodicidade       datetime      not null -- Intervalo de tempo para cada manutenção
  ,constraint pk_manutencao primary key nonclustered (idmanutencao)
);
exec sys.sp_addextendedproperty "ms_description", "Identificador de manutenção (PK)", "user", "dbo", "table", "manutencao", "column","idmanutencao"
exec sys.sp_addextendedproperty "ms_description", "Descrição da manutenção", "user", "dbo", "table", "manutencao", "column","descricao"    
exec sys.sp_addextendedproperty "ms_description", "Intervalo de tempo para cada manutenção", "user", "dbo", "table", "manutencao", "column","periodicidade"
--
-- AUTENTICAÇÃO
--
create table Autenticacao(
   IdAutenticacao      int           not null -- Identificador da  autenticação
  ,Usuario              varchar(100)  not null -- Nome do usuário Administrador
  ,Email                varchar(100)  not null -- Endereço de e-mail do usuário administrador
  ,Senha                varchar(100)  not null -- Senha do usuário administrador
  ,constraint pk_autenticacao primary key nonclustered (idautenticacao)
);
exec sys.sp_addextendedproperty "ms_description", "Identificador da  autenticação (PK)", "user", "dbo", "table", "autenticacao", "column","idautenticacao"
exec sys.sp_addextendedproperty "ms_description", "Nome do usuário Administrador", "user", "dbo", "table", "autenticacao", "column","usuario"    
exec sys.sp_addextendedproperty "ms_description", "Endereço de e-mail do usuário administrador", "user", "dbo", "table", "autenticacao", "column","email"
exec sys.sp_addextendedproperty "ms_description", "Senha do usuário administrador", "user", "dbo", "table", "autenticacao", "column","senha"
--
-- STATUS AGENDAMENTO
--
create table StatusAgendamento(
   IdstatusAgendamento        int          not null  -- Identificador de status de agendamento
  ,Descricao                    varchar(100) not null  -- Status do agendamento
  ,constraint pk_status_agendamento primary key nonclustered (idstatusagendamento)
);
exec sys.sp_addextendedproperty "ms_description", "Identificador de status de agendamento (PK)", "user", "dbo", "table", "statusagendamento", "column","idstatusagendamento"
exec sys.sp_addextendedproperty "ms_description", "Status do agendamento", "user", "dbo", "table", "statusagendamento", "column","descricao"
--
-- STATUS VEÍCULO
--
create table StatusVeiculo(
   IdstatusVeiculo    int          not null  -- Identificador de status do veículo
  ,Descricao            varchar(100) not null  -- Status de veículo
  ,constraint pk_status_veiculo primary key nonclustered (idstatusveiculo)
);
exec sys.sp_addextendedproperty "ms_description", "Identificador de status do veículo (PK)", "user", "dbo", "table", "statusveiculo", "column","idstatusveiculo"
exec sys.sp_addextendedproperty "ms_description", "Status de veículo", "user", "dbo", "table", "statusveiculo", "column","descricao"
--
-- VEICULOS
--
create table Veiculo(
   IdVeiculo            int           not null -- Identificador do veículo
  ,Modelo                varchar(10)       null -- Modelo do veiculo
  ,Km                    float         not null -- Quilometragem atual do veículo
  ,Placa                 varchar(20)   not null -- Identificação da placa do veículo
  ,Tipo                  varchar(10)       null -- Identificação do tipo do veículo
  ,Marca                 varchar(10)       null -- Descrição do modelo do veículo
  ,Cor                   varchar(100)      null -- Descrição da cor do veículo
  ,Ano                   datetime      not null -- Ano de fabricação do veículo
  ,Renavam               numeric       not null -- Número do documento do veículo
  ,Chassi                numeric       not null -- Número da marcação do chassi
  ,IdStatusVeiculo     int               null -- Identificação de status do veículo
  ,Observacao            varchar(300)  not null -- Observação do veículo
  ,constraint pk_veiculo primary key nonclustered (idveiculo)
  , constraint fk_veiculo_statusveiculo foreign key (idstatusveiculo)
    references StatusVeiculo (idstatusveiculo)
    on delete cascade
    on update cascade
);
exec sys.sp_addextendedproperty "ms_description", "Identificador do veículo (PK)", "user", "dbo", "table", "veiculo", "column", "idveiculo"        
exec sys.sp_addextendedproperty "ms_description", "Modelo do veiculo", "user", "dbo", "table", "veiculo", "column","modelo"           
exec sys.sp_addextendedproperty "ms_description", "Quilometragem atual do veículo", "user", "dbo", "table", "veiculo", "column","km"               
exec sys.sp_addextendedproperty "ms_description", "Identificação da placa do veículo", "user", "dbo", "table", "veiculo", "column","placa"
exec sys.sp_addextendedproperty "ms_description", "Identificação do tipo do veículo", "user", "dbo", "table", "veiculo", "column","tipo"             
exec sys.sp_addextendedproperty "ms_description", "Descrição do modelo do veículo", "user", "dbo", "table", "veiculo", "column","marca"            
exec sys.sp_addextendedproperty "ms_description", "Descrição da cor do veículo", "user", "dbo", "table", "veiculo", "column","cor"              
exec sys.sp_addextendedproperty "ms_description", "Ano de fabricação do veículo", "user", "dbo", "table", "veiculo", "column","ano"
exec sys.sp_addextendedproperty "ms_description", "Número do documento do veículo", "user", "dbo", "table", "veiculo", "column","renavam"          
exec sys.sp_addextendedproperty "ms_description", "Número da marcação do chassi", "user", "dbo", "table", "veiculo", "column","chassi"           
--exec sys.sp_addextendedproperty "ms_description", "Identificação de manutenção (FK MANUTENCAO)", "user", "dbo", "table", "veiculo", "column","id_manutencao"    
exec sys.sp_addextendedproperty "ms_description", "Identificação de status do veículo (FK STATUSVEICULO)", "user", "dbo", "table", "veiculo", "column","idstatusveiculo"
exec sys.sp_addextendedproperty "ms_description", "Observação do veículo", "user", "dbo", "table", "veiculo", "column","observacao"
--
-- VEÍCULO MANUTENCAO
--
create table VeiculoManutencao(
   IdVeiculoManutencao    int          not null   -- Identificador do veiculo manutencao
  ,IdVeiculo               int          not null   -- Identificador do veículo
  ,IdManutencao            int           not null   -- Identificador de manutenção
  ,DataManutencao          datetime   not null   -- Data da manutenção
  ,constraint pk_veicmanu primary key nonclustered (idveiculomanutencao)
  , constraint fk_veicmanu_manutencao foreign key (idmanutencao)
    references manutencao (idmanutencao)
  on update no action 
  on delete no action
  , constraint fk_veicmanu_veiculo foreign key (idveiculo)
    references veiculo (idveiculo)
  on update no action 
  on delete no action
);
exec sys.sp_addextendedproperty "ms_description", "Identificador do veiculo manutencao (PK)", "user", "dbo", "table", "veiculomanutencao", "column","idveiculomanutencao"
exec sys.sp_addextendedproperty "ms_description", "Identificador do veículo (FK VEICULO)", "user", "dbo", "table", "veiculomanutencao", "column", "idveiculo" 
exec sys.sp_addextendedproperty "ms_description", "Identificador de manutenção (FK MANUTENCAO)", "user", "dbo", "table", "veiculomanutencao", "column","idmanutencao"
exec sys.sp_addextendedproperty "ms_description", "Data da manutenção", "user", "dbo", "table", "veiculomanutencao", "column","datamanutencao"
--
-- AGENDAMENTOS
--
create table Agendamento(
   IdAgendamento             int        not null -- Identificador do Agendamento
  ,DataInicialPrevista      datetime   not null -- Data Inicial Prevista do Agendamento
  ,DataFinalPrevista        datetime   not null -- Data Final Prevista do Agendamento
  ,IdRota                    int            null -- Identificação da rota
  ,IdVeiculo                 int            null -- Identificação do veículo
  ,IdMotorista               int            null -- Identificação do motorista
  ,DataInicialRealizada     datetime       null -- Data Inicial do Agendamento Realizado
  ,DataFinalRealizada       datetime       null -- Data Final do Agendamento Realizado
  ,KmFinal                   float          null -- Identificação de quilometragem percorrida
  ,IdStatusAgendamento      int            null -- Identificação de status, finalizada em
  ,IdAutenticacao            int            null -- Identificação da autenticação
  ,constraint pk_agendamento primary key nonclustered (idagendamento)
  , constraint fk_agendamento_rota foreign key (idrota)
    references Rota (idrota)
    on delete cascade
    on update cascade
  , constraint fk_agendamento_veiculo foreign key (idveiculo)
    references Veiculo (idveiculo)
    on delete cascade
    on update cascade
  , constraint fk_agendamento_motorista foreign key (idmotorista)
    references Motorista (idmotorista)
    on delete cascade
    on update cascade
  , constraint fk_agendamento_status_agendamento foreign key (idstatusagendamento)
    references StatusAgendamento (idstatusagendamento)
    on delete cascade
    on update cascade
  , constraint fk_agendamento_autenticacao foreign key (idautenticacao)
    references Autenticacao (idautenticacao)
    on delete cascade
    on update cascade
);
exec sys.sp_addextendedproperty "ms_description", "Identificador do Agendamento (PK)", "user", "dbo", "table", agendamento, "column", "idagendamento"
exec sys.sp_addextendedproperty "ms_description", "Data Inicial Prevista do Agendamento", "user", "dbo", "table", agendamento, "column", "datainicialprevista"
exec sys.sp_addextendedproperty "ms_description", "Data Final Prevista do Agendamento", "user", "dbo", "table", agendamento, "column", "datafinalprevista"
exec sys.sp_addextendedproperty "ms_description", "Identificação da rota (FK ROTAS)", "user", "dbo", "table", agendamento, "column", "idrota"
exec sys.sp_addextendedproperty "ms_description", "Identificação do veículo (FK VEICULOS)", "user", "dbo", "table", agendamento, "column", "idveiculo"
exec sys.sp_addextendedproperty "ms_description", "Identificação do motorista (FK MOTORISTAS)", "user", "dbo", "table", agendamento, "column", "idmotorista"
exec sys.sp_addextendedproperty "ms_description", "Data Inicial do Agendamento Realizado", "user", "dbo", "table", agendamento, "column", "datainicialrealizada" 
exec sys.sp_addextendedproperty "ms_description", "Data Final do Agendamento Realizado", "user", "dbo", "table", agendamento, "column", "datafinalrealizada" 
exec sys.sp_addextendedproperty "ms_description", "Quilometragem percorrida", "user", "dbo", "table", agendamento, "column", "kmfinal"
exec sys.sp_addextendedproperty "ms_description", "Identificação de status, finalizada em (FK STATUSAGENDAMENTO)", "user", "dbo", "table", agendamento, "column", "idstatusagendamento" 
exec sys.sp_addextendedproperty "ms_description", "Identificação da autenticação (FK AUTENTICACAO)", "user", "dbo", "table", agendamento, "column", "idautenticacao"
                                                 
INSERT INTO [motorista]
           ([idmotorista]
           ,[nome]
           ,[cpf]
           ,[datavencimentocnh]
           ,[cargo]
           ,[endereco]
           ,[celular]
           ,[tipomotorista]
           ,[datanascimento]
           ,[setor]
           ,[rg])
     VALUES
           (1
           ,'MARIANA'
           ,'00000000001'
           ,'20220618 10:34:09'
           ,'SUPERVISOR'
           ,'RUA 123'
           ,'05491921555'
           ,'CARRO'
           ,'19900415 10:34:09'
           ,'FROTA'
           ,9000000009
       )
--
INSERT INTO [motorista]
           ([idmotorista]
           ,[nome]
           ,[cpf]
           ,[datavencimentocnh]
           ,[cargo]
           ,[endereco]
           ,[celular]
           ,[tipomotorista]
           ,[datanascimento]
           ,[setor]
           ,[rg])
     VALUES
           (2
           ,'IVAN'
           ,'00000000002'
           ,'20250211 07:02:09'
           ,'CONDUTOR'
           ,'RUA TESTE'
           ,'05195342828'
           ,'VAN'
           ,'19860112 18:31:09'
           ,'FROTA'
           ,8000000008
       )
--
INSERT INTO [rota]
           ([idrota]
           ,[origem]
           ,[destino]
           ,[kmpadrao])
     VALUES
           (1
           ,'CAXIAS DO SUL'
           ,'BENTO GONCALVES'
           ,44)
--
INSERT INTO [rota]
           ([idrota]
           ,[origem]
           ,[destino]
           ,[kmpadrao])
     VALUES
           (2
           ,'CAXIAS DO SUL'
           ,'FARROUPILHA'
           ,18.7)
--
INSERT INTO [rota]
           ([idrota]
           ,[origem]
           ,[destino]
           ,[kmpadrao])
     VALUES
           (3
           ,'CAXIAS DO SUL'
           ,'FLORES DA CUNHA'
           ,19.8)
--
INSERT INTO [manutencao]
           ([idmanutencao]
           ,[descricao]
           ,[periodicidade])
     VALUES
           (10
           ,'TROCA DE OLEO'
           ,'20220112 18:31:09')
--
INSERT INTO [manutencao]
           ([idmanutencao]
           ,[descricao]
           ,[periodicidade])
     VALUES
           (20
           ,'CORREIA DO PONTO'
           ,'20220305 07:00:01')
--
INSERT INTO [manutencao]
           ([idmanutencao]
           ,[descricao]
           ,[periodicidade])
     VALUES
           (30
           ,'PASTILHAS DE FREIO'
           ,'20211212 09:02:01')
--
INSERT INTO [autenticacao]
           ([idautenticacao]
           ,[usuario]
           ,[email]
           ,[senha])
     VALUES
           (100
           ,'MARIANA.PEZZI'
           ,'MARIANA.PEZZI@GMAIL.COM'
           ,'MPEZZI')
--
INSERT INTO [autenticacao]
           ([idautenticacao]
           ,[usuario]
           ,[email]
           ,[senha])
     VALUES
           (200
           ,'IVAN.OLIVEIRA'
           ,'IVAN.OLIVEIRA@GMAIL.COM'
           ,'IOLIVEIRA')
--
INSERT INTO [statusagendamento]
           ([idstatusagendamento]
           ,[descricao])
     VALUES
           (1000
           ,'AGUARDANDO')
--
INSERT INTO [statusagendamento]
           ([idstatusagendamento]
           ,[descricao])
     VALUES
           (2000
           ,'INICIADO')
--
INSERT INTO [statusagendamento]
           ([idstatusagendamento]
           ,[descricao])
     VALUES
           (3000
           ,'FINALIZADO')
--
INSERT INTO [statusveiculo]
           ([idstatusveiculo]
           ,[descricao])
     VALUES
           (2
           ,'INATIVO')
--
INSERT INTO [statusveiculo]
           ([idstatusveiculo]
           ,[descricao])
     VALUES
           (1
           ,'ATIVO')
--

INSERT INTO [veiculo]
           ([idveiculo]
           ,[modelo]
           ,[km]
           ,[placa]
           ,[tipo]
           ,[marca]
           ,[cor]
           ,[ano]
           ,[renavam]
           ,[chassi]
           --,[idmanutencao]
           ,[idstatusveiculo]
           ,[observacao])
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
           --,<idmanutencao, int,>
           ,1
           ,'OBS')
--
INSERT INTO [veiculo]
           ([idveiculo]
           ,[modelo]
           ,[km]
           ,[placa]
           ,[tipo]
           ,[marca]
           ,[cor]
           ,[ano]
           ,[renavam]
           ,[chassi]
           --,[idmanutencao]
           ,[idstatusveiculo]
           ,[observacao])
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
           --,<idmanutencao, int,>
           ,1
           ,'TESTE')
--
INSERT INTO [veiculo]
           ([idveiculo]
           ,[modelo]
           ,[km]
           ,[placa]
           ,[tipo]
           ,[marca]
           ,[cor]
           ,[ano]
           ,[renavam]
           ,[chassi]
           --,[idmanutencao]
           ,[idstatusveiculo]
           ,[observacao])
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
           --,<idmanutencao, int,>
           ,2
           ,'INATIVADO')
--

INSERT INTO [veiculomanutencao]
           ([idveiculomanutencao]
           ,[idveiculo]
           ,[idmanutencao]
           ,[datamanutencao])
     VALUES
           (1
           ,11
           ,10
           ,'20201112 09:02:01')
--
INSERT INTO [veiculomanutencao]
           ([idveiculomanutencao]
           ,[idveiculo]
           ,[idmanutencao]
           ,[datamanutencao])
     VALUES
           (6
           ,11
           ,10
           ,'20201213 09:02:01')
--
INSERT INTO [veiculomanutencao]
           ([idveiculomanutencao]
           ,[idveiculo]
           ,[idmanutencao]
           ,[datamanutencao])
     VALUES
           (2
           ,11
           ,20
           ,'20201112 10:15:30')
--
INSERT INTO [veiculomanutencao]
           ([idveiculomanutencao]
           ,[idveiculo]
           ,[idmanutencao]
           ,[datamanutencao])
     VALUES
           (3
           ,11
           ,30
           ,'20201212 11:30:00')
--
INSERT INTO [veiculomanutencao]
           ([idveiculomanutencao]
           ,[idveiculo]
           ,[idmanutencao]
           ,[datamanutencao])
     VALUES
           (4
           ,12
           ,20
           ,'20201226 10:00:12')
--
INSERT INTO [veiculomanutencao]
           ([idveiculomanutencao]
           ,[idveiculo]
           ,[idmanutencao]
           ,[datamanutencao])
     VALUES
           (5
           ,12
           ,30
           ,'20201215 08:20:00')
--
INSERT INTO [agendamento]
           ([idagendamento]
           ,[datainicialprevista]
           ,[datafinalprevista]
           ,[idrota]
           ,[idveiculo]
           ,[idmotorista]
           ,[datainicialrealizada]
           ,[datafinalrealizada]
           ,[kmfinal]
           ,[idstatusagendamento]
           ,[idautenticacao])
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
INSERT INTO [agendamento]
           ([idagendamento]
           ,[datainicialprevista]
           ,[datafinalprevista]
           ,[idrota]
           ,[idveiculo]
           ,[idmotorista]
           ,[datainicialrealizada]
           ,[datafinalrealizada]
           ,[kmfinal]
           ,[idstatusagendamento]
           ,[idautenticacao])
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
INSERT INTO [agendamento]
           ([idagendamento]
           ,[datainicialprevista]
           ,[datafinalprevista]
           ,[idrota]
           ,[idveiculo]
           ,[idmotorista]
           ,[datainicialrealizada]
           ,[datafinalrealizada]
           ,[kmfinal]
           ,[idstatusagendamento]
           ,[idautenticacao])
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
