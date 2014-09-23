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

CREATE TABLE guest (
  guestid bigserial NOT NULL,
  useragent character varying(1024),
  CONSTRAINT pk_guest PRIMARY KEY (guestid)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE guest
  OWNER TO postgres;

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

CREATE TABLE article (
  id bigserial NOT NULL,
  name character varying(256),
  title character varying(1024),
  text character varying(16384),
  image character varying(512),
  createdat timestamp without time zone,
  CONSTRAINT pk_article PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE article
  OWNER TO postgres;


CREATE TABLE brand (
  id serial NOT NULL,
  name character varying(64) NOT NULL,
  logo character varying(512) NOT NULL,
  CONSTRAINT pk_brand PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE brand
  OWNER TO postgres;


CREATE TABLE color (
  id serial NOT NULL,
  code character varying(64) NOT NULL DEFAULT (-1),
  name character varying(64) NOT NULL,
  CONSTRAINT pk_color PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE color
  OWNER TO postgres;


CREATE TABLE form (
  id serial NOT NULL,
  name character varying(64) NOT NULL,
  CONSTRAINT pk_form PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE form
  OWNER TO postgres;

CREATE TABLE guitar (
  id bigserial NOT NULL,
  brand int,
  color int,
  form int,
  image character varying(512),
  CONSTRAINT pk_guitar PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE guitar
  OWNER TO postgres;


CREATE TABLE news (
  id serial NOT NULL
  title character varying(1024),
  text character varying(16384),
  image character varying(512),
  CONSTRAINT pk_news PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE news
  OWNER TO postgres;

CREATE TABLE searchhint (
  id serial NOT NULL,
  searchstepid integer NOT NULL,
  text character varying(256),
  CONSTRAINT pk_searchhint PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE searchhint
  OWNER TO postgres;

insert into guitar values 
(1, 1, 1, 1, '../../ImgStore/1.bmp'),
(2, 1, 2, 1, '../../ImgStore/2.bmp'),
(3, 1, 3, 1, '../../ImgStore/3.bmp'),
(4, 1, 1, 2, '../../ImgStore/4.bmp'),
(5, 1, 2, 2, '../../ImgStore/5.bmp'),
(6, 1, 3, 2, '../../ImgStore/6.bmp'),
(7, 1, 1, 3, '../../ImgStore/7.bmp'),
(8, 1, 2, 3, '../../ImgStore/8.bmp'),
(9, 1, 3, 3, '../../ImgStore/9.bmp'),
(10, 2, 1, 1, '../../ImgStore/10.bmp'),
(11, 2, 2, 1, '../../ImgStore/11.bmp'),
(12, 2, 3, 1, '../../ImgStore/12.bmp'),
(13, 2, 1, 2, '../../ImgStore/13.bmp'),
(14, 2, 2, 2, '../../ImgStore/14.bmp'),
(15, 2, 3, 2, '../../ImgStore/15.bmp'),
(16, 2, 1, 3, '../../ImgStore/16.bmp'),
(17, 2, 2, 3, '../../ImgStore/17.bmp'),
(18, 2, 3, 3, '../../ImgStore/18.bmp'),
(19, 3, 1, 1, '../../ImgStore/19.bmp'),
(20, 3, 2, 1, '../../ImgStore/20.bmp'),
(21, 3, 3, 1, '../../ImgStore/21.bmp'),
(22, 3, 1, 2, '../../ImgStore/22.bmp'),
(23, 3, 2, 2, '../../ImgStore/23.bmp'),
(24, 3, 3, 2, '../../ImgStore/24.bmp'),
(25, 3, 1, 3, '../../ImgStore/25.bmp'),
(26, 3, 2, 3, '../../ImgStore/26.bmp'),
(27, 3, 3, 3, '../../ImgStore/27.bmp');

insert into searchhint values
(1, 1, 'Выбрать форму'),
(2, 2, 'Выбрать фирму'),
(3, 3, 'Выбрать цвет');