CREATE TABLE Brand (
  id serial NOT NULL,
  name character varying(64) NOT NULL,
  logo character varying(512) NOT NULL,
  CONSTRAINT pk_Brand PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Brand
  OWNER TO postgres;

CREATE TABLE ColorFull (
  id serial NOT NULL,
  ColorSimpleId int NOT NULL,
  code character varying(64) NOT NULL DEFAULT (-1),
  name character varying(64) NOT NULL,
  CONSTRAINT pk_ColorFull PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE pk_ColorFull
  OWNER TO postgres;

CREATE TABLE ColorSimple (
  id serial NOT NULL,
  name character varying(64) NOT NULL,
  image character varying(1024) NOT NULL,
  CONSTRAINT pk_ColorSimple PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ColorSimple
  OWNER TO postgres;

CREATE TABLE Parameter (
  Id serial NOT NULL,
  ParentId serial,
  NameNominative character varying(64) NOT NULL,
  NameGenitive character varying(64) NOT NULL,
  CONSTRAINT pk_Parameter PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Parameter
  OWNER TO postgres;

CREATE TABLE ParameterValue (
  Id serial NOT NULL,
  ParameterId serial NOT NULL,
  Name character varying(64) NOT NULL,
  Image character varying(1024) NOT NULL,
  CONSTRAINT pk_ParameterValue PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ParameterValue
  OWNER TO postgres;

CREATE TABLE IncompatibleParameter (
  Id serial NOT NULL,
  ParameterId serial NOT NULL,
  ParameterValue serial NOT NULL,
  IncompatibleParameterId serial NOT NULL,
  IncompatibleParameterValue serial NOT NULL,
  CONSTRAINT pk_IncompatibleParameter PRIMARY KEY (Id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE IncompatibleParameter
  OWNER TO postgres;

CREATE TABLE DesignerImage (
  Id serial NOT NULL,
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
  DesignerImageId serial NOT NULL,
  Parameters character varying(1024) NOT NULL,
  X serial NOT NULL,
  Y serial NOT NULL,
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

CREATE TABLE Guitar (
  id serial NOT NULL,
  brandId int,
  FormId int,
  CONSTRAINT pk_Guitar PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Guitar
  OWNER TO postgres;

CREATE TABLE GuitarWithModel (
  id serial NOT NULL,
  guitarId int,
  Model character varying(128),
  CONSTRAINT pk_GuitarWithModel PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE GuitarWithModel
  OWNER TO postgres;

CREATE TABLE GuitarWithColor (
  id serial NOT NULL,
  GuitarWithModelId int,
  ColorFullId int,
  PhotoUrl character varying(1024),
  IsGreatQualityPhoto boolean,
  CONSTRAINT pk_GuitarWithColor PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE GuitarWithColor
  OWNER TO postgres;

CREATE TABLE GuitarInShop (
  id serial NOT NULL,
  GuitarWithColorId int,
  StoreId int,
  Available boolean,
  Price int,
  CONSTRAINT pk_GuitarInShop PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE GuitarInShop
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

CREATE TABLE SearchHint (
  id serial NOT NULL,
  searchstepid integer NOT NULL,
  text character varying(256),
  CONSTRAINT pk_SearchHint PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE SearchHint
  OWNER TO postgres;

CREATE TABLE Shop (
  id serial NOT NULL,
  Name character varying(128),
  Email character varying(256),
  Phone character varying(16),
  CONSTRAINT pk_Shop PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Shop
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

CREATE TABLE Offer (
  id bigserial NOT NULL,
  available boolean,
  price int,
  categoryid bigint,
  picture character varying(1024),
  store boolean,
  pickup boolean,
  delivery boolean,
  name character varying(256),
  description character varying(1024),
  CONSTRAINT pk_Offer PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE Offer
  OWNER TO postgres;

CREATE TABLE OfferCategory (
  id bigserial NOT NULL,
  parentId bigint,
  name character varying(128),
  CONSTRAINT pk_OfferCategory PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE OfferCategory
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