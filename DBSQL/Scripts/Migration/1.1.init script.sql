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
  IncompatibleParameterValue int NOT NULL,
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
  guestid bigserial NOT NULL,
  useragent character varying(1024),
  CONSTRAINT pk_Guest PRIMARY KEY (guestid)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Guest
  OWNER TO postgres;

CREATE TABLE News (
  id serial NOT NULL,
  title character varying(1024),
  text character varying(16384),
  image character varying(512),
  CONSTRAINT pk_News PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE News
  OWNER TO postgres;

CREATE TABLE UserActionLog (
  id bigserial NOT NULL,
  guestId bigint NOT NULL,
  actionId int NOT NULL,
  target bigint,
  CONSTRAINT pk_UserActionLog PRIMARY KEY (id)
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


/*
CREATE TABLE SchemaVersion (
  id serial NOT NULL,
  CurrentMajorVersion int NOT NULL,
  LastMinorUpdate int NOT NULL,
  CONSTRAINT pk_SchemaVersion PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE SchemaVersion
  OWNER TO postgres;
*/