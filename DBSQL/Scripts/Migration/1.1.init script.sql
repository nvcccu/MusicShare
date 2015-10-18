CREATE TABLE Parameter (
  Id serial NOT NULL,
  ParentId int,
  NameNominative character varying(64) NOT NULL,
  NameGenitive character varying(64) NOT NULL,
  ParameterValueHeight int,
  ParameterValueWidth int,
  CONSTRAINT pk_Parameter PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Parameter
  OWNER TO postgres;

CREATE TABLE ParameterValue (
  Id serial NOT NULL,
  ParameterId int NOT NULL,
  Name character varying(64) NOT NULL,
  ImagePreviewUrl character varying(1024) NOT NULL,
  CONSTRAINT pk_ParameterValue PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ParameterValue
  OWNER TO postgres;

CREATE TABLE PredefinedGuitar (
  Id serial NOT NULL,
  FormId int NOT NULL,
  ParameterValues character varying(64) NOT NULL,
  CONSTRAINT pk_PredefinedGuitar PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE PredefinedGuitar
  OWNER TO postgres;

CREATE TABLE IncompatibleParameter (
  Id serial NOT NULL,
  ParameterId int NOT NULL,
  ParameterValueId int NOT NULL,
  IncompatibleParameterId int NOT NULL,
  IncompatibleParameterValueId int NOT NULL,
  CONSTRAINT pk_IncompatibleParameter PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IncompatibleParameter
  OWNER TO postgres;

CREATE TABLE DesignerImage (
  Id serial NOT NULL,
  Parameters character varying(1024) NOT NULL,
  Url character varying(1024) NOT NULL,
  CONSTRAINT pk_DesignerImage PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE DesignerImage
  OWNER TO postgres;

CREATE TABLE DesignerImagePosition (
  Id serial NOT NULL,
  DesignerImageId int NOT NULL,
  Parameters character varying(1024) NOT NULL,
  X int NOT NULL,
  Y int NOT NULL,
  CONSTRAINT pk_DesignerImagePosition PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE DesignerImagePosition
  OWNER TO postgres;

CREATE TABLE Guest (
  GuestId bigserial NOT NULL,
  UserAgent character varying(1024),
  CONSTRAINT pk_Guest PRIMARY KEY (GuestId)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Guest
  OWNER TO postgres;

CREATE TABLE News (
  Id serial NOT NULL,
  Title character varying(1024),
  Text character varying(16384),
  Image character varying(512),
  CONSTRAINT pk_News PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE News
  OWNER TO postgres;

CREATE TABLE UserActionLog (
  Id bigserial NOT NULL,
  GuestId bigint NOT NULL,
  ActionId int NOT NULL,
  Target bigint,
  Date timestamp without time zone NOT NULL,
  CONSTRAINT pk_UserActionLog PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE UserActionLog
  OWNER TO postgres;

CREATE TABLE Question (
  Id bigserial NOT NULL,
  AccountId int NOT NULL,
  Title character varying(512) NOT NULL,
  Text character varying(8192),
  DateCreated timestamp without time zone NOT NULL,
  WatchNumber int NOT NULL DEFAULT 0,
  VoteNumber int NOT NULL DEFAULT 0,
  CONSTRAINT pk_Question PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Question
  OWNER TO postgres;

CREATE TABLE Answer (
  Id bigserial NOT NULL,
  AccountId int NOT NULL,
  AnswerTo bigint NOT NULL,
  Text character varying(8192),
  DateCreated timestamp without time zone NOT NULL,
  IsSolution boolean NOT NULL DEFAULT FALSE,
  VoteNumber int NOT NULL DEFAULT 0,
  CONSTRAINT pk_Answer PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Answer
  OWNER TO postgres;

CREATE TABLE Account (
  Id serial NOT NULL,
  GuestId int NOT NULL,
  NickName character varying(128) UNIQUE,
  Name character varying(128),
  DateRegistered timestamp without time zone NOT NULL,
  Email character varying(128) UNIQUE,
  Salt character varying(128),
  Password character varying(128),
  CONSTRAINT pk_Account PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Account
  OWNER TO postgres;

CREATE TABLE Article (
  Id serial NOT NULL,
  AuthorId int NOT NULL,
  Title character varying(256) UNIQUE,
  Text character varying(32768),
  DateCreated timestamp without time zone NOT NULL,
  IsModerated boolean NOT NULL DEFAULT FALSE,
  Upvote int NOT NULL DEFAULT 0,
  Downvote int NOT NULL DEFAULT 0,
  WatchNumber int NOT NULL DEFAULT 0,
  CONSTRAINT pk_Article PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Article
  OWNER TO postgres;

CREATE TABLE ProductType (
  Id serial NOT NULL,
  Name character varying(256) UNIQUE NOT NULL,
  CONSTRAINT pk_ProductType PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ProductType
  OWNER TO postgres;

CREATE TABLE Property (
  Id serial NOT NULL,
  Name character varying(256) NOT NULL,
  ProductTypeId int NOT NULL,
  CONSTRAINT pk_Property PRIMARY KEY (Id),
  UNIQUE (Name, ProductTypeId)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Property
  OWNER TO postgres;

CREATE TABLE PropertyValue (
  Id serial NOT NULL,
  Name character varying(256) NOT NULL,
  PropertyId int,
  CONSTRAINT pk_PropertyValue PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE PropertyValue
  OWNER TO postgres;

CREATE TABLE Product (
  Id serial NOT NULL,
  ProductTypeId int,
  Name character varying(512) NOT NULL,
  ImageUrl character varying(1024),
  Price int,
  CONSTRAINT pk_Product PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Product
  OWNER TO postgres;

CREATE TABLE ProductPropertyValue (
  Id serial NOT NULL,
  ProductId int NOT NULL,
  PropertyId int NOT NULL,
  PropertyValueId int NOT NULL,
  CONSTRAINT pk_ProductPropertyValue PRIMARY KEY (Id),
  UNIQUE (ProductId, PropertyId, PropertyValueId)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ProductPropertyValue
  OWNER TO postgres;

CREATE TABLE LessonStat (
  Id serial NOT NULL,
  AccountId int NOT NULL,
  ExercisesSpeed character varying(2048),
  Date date NOT NULL,
  CONSTRAINT pk_LessonStat PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE LessonStat
  OWNER TO postgres;

CREATE TABLE GuitarTechnique (
  Id serial NOT NULL,
  Name character varying(128) NOT NULL,
  ShortName character varying(32) NOT NULL,
  CONSTRAINT pk_GuitarTechnique PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE GuitarTechnique
  OWNER TO postgres;

CREATE TABLE Lesson (
  Id serial NOT NULL,
  GuitarTechniqueId int NOT NULL,
  OrderNumber int NOT NULL,
  PreviousLessonId int,
  NextLessonId int,
  Description character varying(2048) NOT NULL,
  Name character varying(256) NOT NULL,
  Text text NOT NULL,
  OriginalLessonUrl character varying(1024) NOT NULL,
  isModerated boolean NOT NULL DEFAULT FALSE,
  Keywords character varying(512),
  Title character varying(512),
  CONSTRAINT pk_Lesson PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Lesson
  OWNER TO postgres;

CREATE TABLE Exercise (
  Id serial NOT NULL,
  LessonId int,
  Name character varying(256) NOT NULL,
  ImageUrl character varying(1024) NOT NULL,
  AudioUrl character varying(1024),
  DefaultSpeed int NOT NULL,
  AuthorAccountId int NOT NULL,
  IsPublic boolean NOT NULL DEFAULT FALSE,
  CONSTRAINT pk_Exercise PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Exercise
  OWNER TO postgres;

CREATE TABLE Plan (
  Id serial NOT NULL,
  OwnerAccountId int NOT NULL,
  Name character varying(1024) NOT NULL,
  Exercises character varying(2048) NOT NULL,
  Type int NOT NULL,
  IsPublic boolean NOT NULL DEFAULT FALSE,
  CONSTRAINT pk_Plan PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Plan
  OWNER TO postgres;

CREATE TABLE StatPreset (
  Id serial NOT NULL,
  OwnerAccountId int NOT NULL,
  Name character varying(1024) NOT NULL,
  Exercises character varying(2048) NOT NULL,
  CONSTRAINT pk_StatPreset PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE StatPreset
  OWNER TO postgres;

CREATE TABLE DerzkiyAccount (
  Id serial NOT NULL,
  CONSTRAINT pk_DerzkiyAccount PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE DerzkiyAccount
  OWNER TO postgres;

CREATE TABLE LessonHistory (
  Id serial NOT NULL,
  AccountId int NOT NULL,
  LessonId int NOT NULL,
  Text text NOT NULL,
  DateCreated timestamp without time zone NOT NULL,
  Comment character varying(2048) NOT NULL,
  CONSTRAINT pk_LessonHistory PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE LessonHistory
  OWNER TO postgres;

CREATE TABLE Homework (
  Id serial NOT NULL,
  AccountId int NOT NULL,
  LessonId int NOT NULL,
  DateCreated timestamp without time zone NOT NULL,
  Link character varying(2048) NOT NULL,
  CONSTRAINT pk_Homework PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Homework
  OWNER TO postgres;