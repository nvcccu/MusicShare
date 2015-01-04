insert into GuitarWithColor values 
(1, 1, 1, '../../ImgStore/Guitars/1.jpg', true),
(2, 1, 2, '../../ImgStore/Guitars/2.jpg', true),
(3, 1, 3, '../../ImgStore/Guitars/3.jpg', true),
(4, 2, 2, '../../ImgStore/Guitars/4.jpg', true),
(5, 2, 3, '../../ImgStore/Guitars/5.jpg', true),
(6, 2, 5, '../../ImgStore/Guitars/6.jpg', true),
(7, 2, 6, '../../ImgStore/Guitars/7.jpg', true),
(8, 3, 5, '../../ImgStore/Guitars/8.jpg', true),
(9, 3, 2, '../../ImgStore/Guitars/9.jpg', true),
(10, 3, 1, '../../ImgStore/Guitars/10.jpg', true),
(11, 4, 2, '../../ImgStore/Guitars/11.jpg', true),
(12, 4, 3, '../../ImgStore/Guitars/12.jpg', true),
(13, 5, 1, '../../ImgStore/Guitars/13.jpg', true),
(14, 5, 2, '../../ImgStore/Guitars/14.jpg', true),
(15, 5, 3, '../../ImgStore/Guitars/15.jpg', true),
(16, 5, 4, '../../ImgStore/Guitars/16.jpg', true),
(17, 5, 5, '../../ImgStore/Guitars/17.jpg', true),
(18, 5, 6, '../../ImgStore/Guitars/18.jpg', true),
(19, 6, 1, '../../ImgStore/Guitars/19.jpg', true),
(20, 6, 2, '../../ImgStore/Guitars/20.jpg', true),
(21, 6, 5, '../../ImgStore/Guitars/21.jpg', true);

insert into Brand values
(1, 'Fender', '../../ImgStore/BrandLogo/Fender.jpg'),
(2, 'Gibson', '../../ImgStore/BrandLogo/Gibson.jpg'),
(3, 'Jackson', '../../ImgStore/BrandLogo/Jackson.jpg'),
(4, 'Cruiser', '../../ImgStore/BrandLogo/Cruiser.jpg'),
(5, 'Jet', '../../ImgStore/BrandLogo/Jet.jpg'),
(6, 'Lag', '../../ImgStore/BrandLogo/Lag.jpg'),
(7, 'Flight', '../../ImgStore/BrandLogo/Flight.jpg'),
(8, 'Yamaha', '../../ImgStore/BrandLogo/Yamaha.jpg'),
(9, 'Ibanez', '../../ImgStore/BrandLogo/Ibanez.jpg'),
(10, 'Epihone', '../../ImgStore/BrandLogo/Epihone.jpg'),
(11, 'Hohner', '../../ImgStore/BrandLogo/Hohner.jpg'),
(12, 'Terris', '../../ImgStore/BrandLogo/Terris.jpg'),
(13, 'Godin', '../../ImgStore/BrandLogo/Godin.jpg'),
(14, 'Erg', '../../ImgStore/BrandLogo/Erg.jpg'),
(15, 'Aria', '../../ImgStore/BrandLogo/Aria.jpg'),
(16, 'Ashtone', '../../ImgStore/BrandLogo/Ashtone.jpg'),
(17, 'Burny', '../../ImgStore/BrandLogo/Burny.jpg'),
(18, 'B.C.Rich', '../../ImgStore/BrandLogo/B_C_Rich.jpg'),
(19, 'Fernandes', '../../ImgStore/BrandLogo/Fernandes.jpg'),
(20, 'Greg Bennett', '../../ImgStore/BrandLogo/Greg_Bennett.jpg'),
(21, 'LTD by ESP', '../../ImgStore/BrandLogo/LTD_by_ESP.jpg'),
(22, 'Magna', '../../ImgStore/BrandLogo/Magna.jpg'),
(23, 'Pignose', '../../ImgStore/BrandLogo/Pignose.jpg'),
(24, 'Samic', '../../ImgStore/BrandLogo/Samic.jpg'),
(25, 'Shecter', '../../ImgStore/BrandLogo/Shecter.jpg'),
(26, 'Stagg', '../../ImgStore/BrandLogo/Stagg.jpg'),
(27, 'Washburn', '../../ImgStore/BrandLogo/Washburn.jpg'),
(28, 'Zombie', '../../ImgStore/BrandLogo/Zombie.jpg');


insert into Color values
(1, 'Белый', '/ImgStore/Color/White.jpg'),
(2, 'Черный', '/ImgStore/Color/Black.jpg'),
(3, 'Красный', '/ImgStore/Color/Red.jpg');

insert into Form values
(1, 'Stratocaster', '/ImgStore/Form/Stratocaster.jpg'),
(2, 'Telecaster', '/ImgStore/Form/Telecaster.jpg'),
(3, 'Explorer', '/ImgStore/Form/Explorer.jpg'),
(4, 'Les Paul', '/ImgStore/Form/Les_Paul.jpg'),
(5, 'RandyRhoads', '/ImgStore/Form/RandyRhoads.jpg'),
(6, 'Flying V', '/ImgStore/Form/Flying_V.jpg'),
(7, 'SG', '/ImgStore/Form/SG.jpg'),
(8, 'PRS Santana', '/ImgStore/Form/PRS_Santana.jpg');

insert into FormWithColor values
(1, 1, 3, 'Red Stratocaster', '/ImgStore/FormWithColor/Stratocaster_Red.jpg'),
(2, 1, 1, 'White Stratocaster', '/ImgStore/FormWithColor/Stratocaster_White.jpg'),
(3, 1, 2, 'Black Stratocaster', '/ImgStore/FormWithColor/Stratocaster_Black.jpg'),
(4, 3, 3, 'Red Explorer', '/ImgStore/FormWithColor/Explorer_Red.jpg'),
(5, 3, 1, 'White Explorer', '/ImgStore/FormWithColor/Explorer_White.jpg'),
(6, 3, 2, 'Black Explorer', '/ImgStore/FormWithColor/Explorer_Black.jpg'),
(7, 5, 3, 'Red RandyRhoads', '/ImgStore/FormWithColor/RandyRhoads_Red.jpg'),
(8, 5, 1, 'White RandyRhoads', '/ImgStore/FormWithColor/RandyRhoads_White.jpg'),
(9, 5, 2, 'Black RandyRhoads', '/ImgStore/FormWithColor/RandyRhoads_Black.jpg');

insert into ColorSimple values
(1, 'Black', '../../ImgStore/ColorSimple/Black.jpg'),
(2, 'White', '../../ImgStore/ColorSimple/White.jpg'),
(3, 'Red', '../../ImgStore/ColorSimple/Red.jpg');

insert into ColorFull values 
(1, 1, 'lbk', 'Light Black'),
(2, 1, 'bk', 'Black'),
(3, 2, 'slv', 'Silver'),
(4, 2, 'wh', 'White'),
(5, 3, 'rd', 'Red'),
(6, 3, 'or', 'Orange');

insert into Guitar values 
(1, 1, 1),
(2, 1, 2),
(3, 2, 3),
(4, 2, 4),
(5, 3, 5),
(6, 3, 6);

insert into GuitarWithModel values 
(1, 1, 'Fender Strat'),
(2, 2, 'Fender Telec'),
(3, 3, 'Gibson Explorer'),
(4, 4, 'Gibson LP'),
(5, 5, 'Jackson RR'),
(6, 6, 'Jackson FV');

insert into searchhint values
(1, 1, 'Выбрать форму'),
(2, 2, 'Выбрать фирму'),
(3, 3, 'Выбрать цвет');