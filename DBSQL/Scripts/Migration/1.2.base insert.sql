insert into guest values
(1, '');

insert into Parameter values
(1, NULL, 'Корпус', 'корпуса', null, null),
(2, 1, 'Форма', 'формы', 193, 129),
(3, 1, 'Цвет', 'цвета', 100, 100),
(4, NULL, 'Бридж', 'бриджа', null, null),
(7, 4, 'Тип', 'типа', 88, 141);

insert into ParameterValue values
(1, 2, 'Stratocaster', '/ImgStore/Form/Stratocaster.png'),
(2, 2, 'Explorer', '/ImgStore/Form/Explorer.png'),
(3, 2, 'Les Paul', '/ImgStore/Form/LesPaul.png'),
(4, 3, 'Белый', '/ImgStore/Color/White.png'),
(5, 3, 'Черный', '/ImgStore/Color/Black.png'),
(6, 3, 'Красный', '/ImgStore/Color/Red.png'),
(7, 7, 'Floyd Rose', '/ImgStore/Bridge/FloydRose.png'),
(8, 7, 'Tune-o-Matic', '/ImgStore/Bridge/TuneOMatic.png'),
(9, 7, 'Vintage Tremolo', '/ImgStore/Bridge/VintageTremolo.png');

insert into PredefinedGuitar values
(1, 1, '7:8;3:4'),
(2, 1, '7:9;3:5'),
(3, 2, '7:7;3:6'),
(4, 2, '7:8;3:4'),
(5, 3, '7:7;3:5'),
(6, 3, '7:8;3:6');

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
(11, 10, '2:2;', 177, 161),
(12, 10, '2:3;', 113, 93),
(13, 11, '2:1;', 91, 93),
(14, 11, '2:2;', 185, 156),
(15, 11, '2:3;', 121, 88),
(16, 12, '2:1;', 98, 103);

insert into ProductType values
(1, 'Электрогитары'),
(2, 'Синтезаторы'),
(3, 'Ударные'),
(4, 'Баяны'),
(5, 'Бояны'),
(6, 'азаза38');

insert into Property values
(1, 'Цвет', 1),
(2, 'Форма', 1),
(3, 'Бридж', 1),
(4, 'Число клавиш', 2),
(5, 'Фирма', 2),
(6, 'Число инструментов', 2),
(7, 'Бочка', 3),
(8, 'Рабочий', 3),
(9, 'Кардан', 3),
(10, 'Рваные', 4),
(11, 'Старые', 4),
(12, 'Смешные', 4),
(13, 'Рваные', 5),
(14, 'Смешные', 5),
(15, 'Старые', 5),
(16, 'а', 6),
(17, 'аза', 6),
(18, 'азаза', 6);

insert into PropertyValue values
(1, 'Белый', 1),
(2, 'Черный', 1),
(3, 'Красный', 1),
(4, 'Les Paul', 2),
(5, 'Stratocaster', 2),
(6, 'Explorer', 2),
(7, 'Vintage Tremolo', 3),
(8, 'Fixed', 3),
(9, 'Tune-o-Matic', 3);

insert into GuitarTechnique values
(1, 'Я новичок!'),
(2, 'Переменный штрих'),
(3, 'Легатная техника'),
(4, 'Технические приемы'),
(5, 'Ритм-гитара'),
(6, 'Теппинг'),
(7, 'Свип'),
(8, 'Шред'),
(9, 'Фортепианная техника'),
(10, 'Седьмая струна');

insert into lesson values
(1, 3, 1, 'Основы легато', '<p><img src="http://allfrets.ru/images/stories/line.jpg" border="0" style="text-align: justify;"></p>
<p class="MsoNormal" style="text-align: justify; ">Вслушиваясь в произведения таких гитаристов, к Джо Сатриани и Стив Вай, ты зачастую можешь услышать длинные слитные каскады нот, сыгранные с сумасшедшей скоростью. <span style="text-align: justify; ">Эта техника называется легатной. Пришедшее из итальянского, слово легато означает «сглаженный» и в полной мере передает суть техники.</span></p>
<p class="MsoNormal" style="text-align: justify; "><span style="text-align: justify; "><br></span></p>
<p class="MsoNormal" style="text-align: justify;">Итак, какие приемы используются в легатной технике? Их всего три:</p>
<p class="MsoNormal" style="text-align: justify;"><img src="http://allfrets.ru/images/stories/legato/1_type.jpg" border="0"></p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal"><strong>ХАММЕР</strong> – 1-ый такт</p>
<p class="MsoNormal"><strong>ПУЛ </strong>– 2-ой такт</p>
<p class="MsoNormal"><strong>СЛАЙД</strong> – 3-ий такт</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify; ">Однако какой бы легатной не была легатная техника того или иного гитариста, рано или поздно он разбавит ее парой медиаторных ударов. Это лишь вопрос времени. А потому не стоит воспринимать легатную технику, как нечто совершенно обособленное от любых других способов игры на гитаре. Легато в твоем исполнении должно превратиться в мощное средство, но никак не в цель.</p>
<p class="MsoNormal" style="text-align: justify;">Одним из самых сложных моментов легатной техники, по моему мнению, является ПУЛ. При этом сложность его выполнения напрямую зависит от задействованных для этого пальцев.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em>Упражнение 1. Выполни уже знакомое тебе упражнение.</em></p>
<p class="MsoNormal" style="text-align: justify;"><img src="http://allfrets.ru/images/stories/legato/1_legato_1.jpg" border="0"></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Что ты чувствуешь? Какая комбинация пальцев вызывает наибольшее&nbsp;затруднение? Ниже я расположу все варианты в порядке их усложнения.</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;"><strong>1. Первый и третий</strong></p>
<p class="MsoNormal" style="text-align: justify;"><strong> </strong><strong>2. Первый и второй</strong></p>
<p class="MsoNormal" style="text-align: justify;"><strong> </strong><strong>3. Первый и четвертый</strong></p>
<p class="MsoNormal" style="text-align: justify;"><strong> </strong><strong>4. Второй и третий</strong></p>
<p class="MsoNormal" style="text-align: justify;"><strong> </strong><strong>5. Второй и четвертый</strong></p>
<p class="MsoNormal" style="text-align: justify;"><strong> </strong><strong>6. Третий и четвертый</strong></p>
<p>&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">От этого списка напрямую зависит время, которое ты должен уделять той или иной комбинации пальцев. Если выполнить пул и хаммер для первого и второго пальца тебе не составляет труда, то и не стоит на них зацикливаться. С другой стороны третий и четвертый пальцы нуждаются в ежедневных упражнениях. Хочется сказать также, что я составил этот список, основываясь на своих личных ощущениях и, возможно для тебя он будет немного другим.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Вот пара упражнений из книги «Упражнения из ада». Немного выше я говорил о том, что легато часто разбавляется ударами медиатора. Это как раз тот случай. Выполнить такие упражнения гораздо проще, чем полностью легатные, поэтому с них мы и начнем.</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;"><em>Упражнение 2. Не забывай соблюдать правильную последовательность ударов. Если взять первые четыре ноты, то первая берется ударом вниз, четвертая – ударом вверх.</em></p>
<p class="MsoNormal" style="text-align: justify;"><img src="http://allfrets.ru/images/stories/legato/1_legato_2.jpg" border="0"></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;"><em>Упражнение 3. Похожее упражнение. Здесь, как и в предыдущем пассаже добейся скорости исполнения в 160 УВМ. Не забывай о последовательности ударов.</em></p>
<p class="MsoNormal"><em><img src="http://allfrets.ru/images/stories/legato/1_legato_3.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Теперь перейдем к книге Троя Стетины «<span lang="EN-US">Guitar</span><span lang="EN-US"> </span><span lang="EN-US">Shred</span>»</p>
<p class="MsoNormal"><em>Упражнение 4. Продолжай его до восьмого лада.</em></p>
<p class="MsoNormal" style="text-align: justify;"><img src="http://allfrets.ru/images/stories/legato/1_legato_4.jpg" border="0"></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Одной из главных задач гитариста, взявшегося осваивать легатную технику, да вообще любого гитариста является развитие независимости пальцев. В следующем уроке это станет для тебя целью номер один. А сейчас я приведу пару несложных упражнений из книги «<span lang="EN-US">The</span><span lang="EN-US"> </span><span lang="EN-US">Ultimate</span><span lang="EN-US"> </span><span lang="EN-US">Guitar</span><span lang="EN-US"> </span><span lang="EN-US">Workout</span>», предназначенных для этого.</p>
<p class="MsoNormal" style="text-align: justify;"><em>Упражнение 5. Здесь ноты объединены в сикстоли. Дойди до скорости в 120 УВМ.</em></p>
<p class="MsoNormal"><em><img src="http://allfrets.ru/images/stories/legato/1_legato_5.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em>Упражнение 6. По сути – это четыре очень похожих друг на друга упражнения.</em></p>
<p class="MsoNormal"><em><img src="http://allfrets.ru/images/stories/legato/1_legato_6.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;"><em>Упражнение 7. И в заключение еще несколько упражнений, которые так же, как и предыдущее отличаются друг от друга лишь задействованными пальцами. Каждые пять нот объединены в одну группу.</em></p>
<p class="MsoNormal"><em><img src="http://allfrets.ru/images/stories/legato/1_legato_7.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal"><em><br></em></p>
<p class="MsoNormal" style="text-align: justify;">Легатная техника – чертовски полезная вещь! Постарайся не обойти ее своим вниманием, и уделить ее развитию время. В итоге ты сможешь играть гораздо быстрее и слитнее – а это один из признаков хорошего гитариста. В следующем уроке ты будешь работать над независимостью пальцев, затем мы перейдем к полностью легатным пассажам. Апофеозом этой части станет трюк, который ты мог видеть на концертах Джо Сатриани и Стива Вая – ты научишься играть одной левой рукой, при этом правая будет глушить струны ниже левой. Круто, не правда ли! Если что-то осталось непонятным - спрашивай! Удачи!</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: center;"><a href="/forum/viewtopic.php?f=2&amp;t=688" title="Форум - легато">ОБСУДИТЬ НА ФОРУМЕ</a></p>
<p class="MsoNormal" style="text-align: right;"><a href="/legatotechnique/legatofinger" title="Развитие независимости пальцев">СЛЕДУЮЩИЙ УРОК &gt;&gt;</a></p>');