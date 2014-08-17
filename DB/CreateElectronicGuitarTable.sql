CREATE TABLE electronicguitar (
  id bigserial NOT NULL,
  brand character varying(64) NOT NULL,
  model character varying(64) NOT NULL,
  color character varying(256),
  form character varying(512),
  bodymaterial character varying(512),
  neckmaterial character varying(512),
  pickguard character varying(512),
  mensuration character varying(64),
  tremolosystem character varying(512),
  pickup character varying(512),
  electronic character varying(512),
  pin character varying(512),
  islefthand boolean,
  availablenow boolean,
  image character varying(512),
  price numeric(8,3) NOT NULL,
  url character varying(512) NOT NULL,
  CONSTRAINT pk_electronicguitar PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE electronicguitar
  OWNER TO postgres;