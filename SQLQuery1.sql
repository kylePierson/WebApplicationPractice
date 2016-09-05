DROP TABLE campground;
DROP TABLE park;

CREATE TABLE park (
  park_id integer identity NOT NULL,
  name varchar(80) NOT NULL,          -- Name of the park
  location varchar(50) NOT NULL,      -- State name(s) where park is located
  establish_date date NOT NULL,       -- Date park was established
  area integer NOT NULL,              -- Area in acres
  visitors integer NOT NULL,          -- Latest recorded number of annual visitors
  description varchar(500) NOT NULL,  
  CONSTRAINT pk_park_park_id PRIMARY KEY (park_id)
);

CREATE TABLE campground (
  campground_id integer identity NOT NULL,
  park_id integer NOT NULL,				  -- Parent park
  name varchar(80) NOT NULL,			  -- Name of the campground
  location varchar(max) NOT NULL,         -- Campground Location
  utility_hookup varchar(max) NOT NULL,  
  dump_station varchar(max) NOT NULL,
  CONSTRAINT pk_campground_campground_id PRIMARY KEY (campground_id)
);

CREATE TABLE mailinglist (
  entry_id integer identity NOT NULL,
  firstname varchar(15) NOT NULL,
  lastname varchar(15) NOT NULL,
  email varchar(30) NOT NULL,
  phone_number varchar(15) NOT NULL,
  address varchar(75),
  CONSTRAINT pk_mailinglist_entry_id PRIMARY KEY (entry_id)
);

-- Yosemite
INSERT INTO park (name, location, establish_date, area, visitors, description)
VALUES ('Yosemite', 'California', '1890-10-01', 748000, 3883129, 'Yosemite National Park is in California’s Sierra Nevada mountains. It’s famed for its giant, ancient sequoia trees, and for Tunnel View, the iconic vista of towering Bridalveil Fall and the granite cliffs of El Capitan and Half Dome. In Yosemite Village are shops, restaurants, lodging, the Yosemite Museum and the Ansel Adams Gallery, with prints of the photographer’s renowned black-and-white landscapes of the area.');

-- Yosemite Campgrounds
INSERT INTO campground (park_id, name, location, utility_hookup, dump_station) 
VALUES (1, 'Wawona', 'On the Wawona Road, one mile north of Wawona, at 4,000 ft (1,200 m) elevation', 'No', 'Yes, summer only (on Forest Drive east of the Pioneer Gift & Grocery, formerly Wawona Store)');

INSERT INTO campground (park_id, name, location, utility_hookup, dump_station) 
VALUES (1, 'Hodgdon Meadow', 'Off the Big Oak Flat Road (Highway 120), about 45 minutes northwest of Yosemite Valley and adjacent to the Big Oak Flat Entrance Station, at 4,900 ft (1,500 m)', 'No', 'No, but available all year in Yosemite Valley (in Upper Pines Campground)');

INSERT INTO campground (park_id, name, location, utility_hookup, dump_station) 
VALUES (1, 'Bridalveil Creek', 'Off the Glacier Point Road, about 8 miles east of its intersection of the Wawona Road (Highway 41), and about 45 minutes south of Yosemite Valley or 45 minutes north of Wawona, at 7,200 ft (2,200 m) elevation', 'No', 'No, but available summer only (on Forest Drive east of the Pioneer Gift & Grocery, formerly Wawona Store) and all year in Yosemite Valley (in Upper Pines Campground)');



ALTER TABLE campground ADD FOREIGN KEY (park_id) REFERENCES park(park_id);