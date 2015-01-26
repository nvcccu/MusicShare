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

insert into Parameter values
(1, NULL, 'корпус', 'корпуса'),
(2, 1, 'форма', 'формы'),
(3, 1, 'цвет', 'цвета'),
(4, NULL, 'бридж', 'бриджа'),
(5, NULL, 'производитель', 'производителя'),
(6, 5, 'производитель', 'производителя'),
(7, 4, 'бридж', 'бриджа');

insert into ParameterValue values
(1, 2, 'Stratocaster', '/ImgStore/FormWithColor/Stratocaster_NoColor.png'),
(2, 2, 'Explorer', '/ImgStore/FormWithColor/Explorer_NoColor.png'),
(3, 2, 'Les Paul', '/ImgStore/FormWithColor/LesPaul_NoColor.png'),
(4, 3, 'Белый', '/ImgStore/Color/White.jpg'),
(5, 3, 'Черный', '/ImgStore/Color/Black.jpg'),
(6, 3, 'Красный', '/ImgStore/Color/Red.jpg'),
(7, 7, 'Floyd Rose', '/ImgStore/Bridge/FloydRose.png'),
(8, 7, 'Tune-o-Matic', '/ImgStore/Bridge/TuneOMatic.png'),
(9, 7, 'Vintage Tremolo', '/ImgStore/Bridge/VintageTremolo.png'),
(10, 6, 'Fender', '/ImgStore/BrandLogo/Fender.jpg'),
(11, 6, 'Gibson', '/ImgStore/BrandLogo/Gibson.jpg');

insert into IncompatibleParameter values
(1, 5, 10, 2, 2),
(2, 5, 10, 3, 2),
(3, 5, 11, 1, 2);

insert into DesignerImage values
(1, '2:1;3:6;', '/ImgStore/FormWithColor/Stratocaster_Red.png'),
(2, '2:1;3:4;', '/ImgStore/FormWithColor/Stratocaster_White.png'),
(3, '2:1;3:5;', '/ImgStore/FormWithColor/Stratocaster_Black.png'),
(4, '2:2;3:6;', '/ImgStore/FormWithColor/Explorer_Red.png'),
(5, '2:2;3:4;', '/ImgStore/FormWithColor/Explorer_White.png'),
(6, '2:2;3:5;', '/ImgStore/FormWithColor/Explorer_Black.png'),
(7, '2:3;3:6;', '/ImgStore/FormWithColor/LesPaul_Red.png'),
(8, '2:3;3:4;', '/ImgStore/FormWithColor/LesPaul_White.png'),
(9, '2:3;3:5;', '/ImgStore/FormWithColor/LesPaul_Black.png'),
(10, '7:7;', '/ImgStore/Bridge/FloydRose.png'),
(11, '7:8;', '/ImgStore/Bridge/TuneOMatic.png'),
(12, '7:9;', '/ImgStore/Bridge/VintageTremolo.png');

insert into DesignerImagePosition values
(1, 1, '', 0, 0),
(2, 2, '', 0, 0),
(3, 3, '', 0, 0),
(4, 4, '', 0, 0),
(5, 5, '', 0, 0),
(6, 6, '', 0, 0),
(7, 7, '', 0, 0),
(8, 8, '', 0, 0),
(9, 9, '', 0, 0),
(10, 10, '2:1;', 100, 100),
(11, 10, '2:2', 50, 100),
(12, 10, '2:3', 100, 50),
(13, 11, '2:1;', 100, 100),
(14, 11, '2:2;', 50, 100),
(15, 11, '2:3;', 100, 50),
(16, 12, '2:1;', 100, 100),
(17, 12, '2:2;', 50, 100),
(18, 12, '2:3;', 100, 50);

insert into ColorSimple values
(1, 1 '/ImgStore/FormWithColor/Stratocaster_Red.png', 0, 0),
(2, 2 '/ImgStore/FormWithColor/Stratocaster_White.png', 0, 0),
(3, 3 '/ImgStore/FormWithColor/Stratocaster_Black.png', 0, 0),
(4, 4 '/ImgStore/FormWithColor/Explorer_Red.png', 0, 0),
(5, 5 '/ImgStore/FormWithColor/Explorer_White.png', 0, 0),
(6, 6 '/ImgStore/FormWithColor/Explorer_Black.png', 0, 0),
(7, 7 '/ImgStore/FormWithColor/LesPaul_Red.png', 0, 0),
(8, 8 '/ImgStore/FormWithColor/LesPaul_White.png', 0, 0),
(9, 9 '/ImgStore/FormWithColor/LesPaul_Black.png', 0, 0),
(10, 10 '/ImgStore/Bridge/FloydRose.png', 0, 0),
(11, 11 '/ImgStore/Bridge/TuneOMatic.png', 0, 0),
(12, 12 '/ImgStore/Bridge/VintageTremolo.png', 0, 0);

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