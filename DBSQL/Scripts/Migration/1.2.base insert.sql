insert into GuitarWithColor values 
(1, 1, 1, '../../ImgStore/1.jpg', true),
(2, 1, 2, '../../ImgStore/2.jpg', true),
(3, 1, 3, '../../ImgStore/3.jpg', true),
(4, 2, 2, '../../ImgStore/4.jpg', true),
(5, 2, 3, '../../ImgStore/5.jpg', true),
(6, 2, 5, '../../ImgStore/6.jpg', true),
(7, 2, 6, '../../ImgStore/7.jpg', true),
(8, 3, 5, '../../ImgStore/8.jpg', true),
(9, 3, 2, '../../ImgStore/9.jpg', true),
(10, 3, 1, '../../ImgStore/10.jpg', true),
(11, 4, 2, '../../ImgStore/11.jpg', true),
(12, 4, 3, '../../ImgStore/12.jpg', true),
(13, 5, 1, '../../ImgStore/13.jpg', true),
(14, 5, 2, '../../ImgStore/14.jpg', true),
(15, 5, 3, '../../ImgStore/15.jpg', true),
(16, 5, 4, '../../ImgStore/16.jpg', true),
(17, 5, 5, '../../ImgStore/17.jpg', true),
(18, 5, 6, '../../ImgStore/18.jpg', true),
(19, 6, 1, '../../ImgStore/19.jpg', true),
(20, 6, 2, '../../ImgStore/20.jpg', true),
(21, 6, 5, '../../ImgStore/21.jpg', true);

insert into Brand values
(1, 'Fender', '../../ImgStore/BrandLogo/Fender.jpg'),
(2, 'Gibson', '../../ImgStore/BrandLogo/Gibson.jpg'),
(3, 'Jackson', '../../ImgStore/BrandLogo/Jackson.jpg');

insert into Form values
(1, 'Stratocaster', '../../ImgStore/Form/Stratocaster.jpg'),
(2, 'Telecaster', '../../ImgStore/Form/Stratocaster.jpg'),
(3, 'Explorer', '../../ImgStore/Form/Explorer.jpg'),
(4, 'Les Paul', '../../ImgStore/Form/Les_Paul.jpg'),
(5, 'RandyRhoads', '../../ImgStore/Form/RandyRhoads.jpg'),
(6, 'Flying V', '../../ImgStore/Form/Flying_V.jpg');

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
(1, 1, 1, '11'),
(2, 1, 2, '12'),
(3, 2, 3, '23'),
(4, 2, 4, '24'),
(5, 3, 5, '36'),
(6, 3, 6, '35');

insert into searchhint values
(1, 1, 'Выбрать форму'),
(2, 2, 'Выбрать фирму'),
(3, 3, 'Выбрать цвет');