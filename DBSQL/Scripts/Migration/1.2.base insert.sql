insert into guest values
(1, '');

insert into Parameter values
(1, NULL, 'корпус', 'корпуса', null, null),
(2, 1, 'форма', 'формы', 230, 139),
(3, 1, 'цвет', 'цвета', 100, 100),
(4, NULL, 'бридж', 'бриджа', null, null),
(7, 4, 'тип', 'типа', 100, 200);

insert into ParameterArrow values
(1, 14, '2:', 100, 200);

insert into ParameterValue values
(1, 2, 'Stratocaster', '/ImgStore/Form/Stratocaster.png'),
(2, 2, 'Explorer', '/ImgStore/Form/Explorer.png'),
(3, 2, 'Les Paul', '/ImgStore/Form/LesPaul.png'),
(4, 3, 'Белый', '/ImgStore/Color/White.jpg'),
(5, 3, 'Черный', '/ImgStore/Color/Black.jpg'),
(6, 3, 'Красный', '/ImgStore/Color/Red.jpg'),
(7, 7, 'Floyd Rose', '/ImgStore/Bridge/FloydRose.png'),
(8, 7, 'Tune-o-Matic', '/ImgStore/Bridge/TuneOMatic.png'),
(9, 7, 'Vintage Tremolo', '/ImgStore/Bridge/VintageTremolo.png');


insert into PredefinedGuitar values
(1, 1, '7:8;'),
(2, 1, '7:9;'),
(3, 2, '7:7;'),
(4, 2, '7:8;'),
(5, 3, '7:7;'),
(6, 3, '7:8;');

insert into IncompatibleParameter values
(7, 7, 9, 2, 2),
(8, 7, 9, 2, 3),
(9, 2, 2, 7, 9),
(10, 2, 3, 7, 9);

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
(10, 10, '2:1;', 81, 97),
(11, 10, '2:2;', 171, 154),
(12, 10, '2:3;', 113, 93),
(13, 11, '2:1;', 91, 93),
(14, 11, '2:2;', 177, 149),
(15, 11, '2:3;', 121, 88),
(16, 12, '2:1;', 98, 103);
