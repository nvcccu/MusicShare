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
(1, 3, 1, 7, 'Основы легато', '<p><img src="http://allfrets.ru/images/stories/line.jpg" border="0" style="text-align: justify;"></p>
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


insert into lesson values
(2, 2, 2, 12, 'Штрих при переходе со струны на струну', '<h5><img src="/images/stories/line.jpg" border="0"></h5>
<h5><a href="/altpicking/singlestringpicking" title="Переменный штрих на одной струне" style="margin: 0px; padding: 0px; border: 0px; outline: 0px; font-size: 13px; color: #40678a; font-family: Arial, Helvetica, sans-serif; line-height: 23px; text-align: justify;">&lt;&lt; ПРЕДЫДУЩИЙ УРОК</a></h5>
<p>&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Привет! Я рад, что ты достиг скорости в 60 УВМ при игре переменным штрихом на одной струне. Если нет, тогда вернись к <a href="/altpicking/singlestringpicking" title="Переменный штрих на одной струне">предыдущему уроку</a>. Если же это так, тогда продолжим обучение игре на электрогитаре. Если ты еще не умеешь настраивать гитару, обратись к <a href="/beginner/howtotuneaguitar" title="Настройка гитары">соответствующему уроку</a>. То же и с <a href="/beginner/howtoreadtabs" title="Как читать табулатуры">чтением табулатур</a>.</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<h5 style="text-align: justify;">РАЗНОВИДНОСТИ ШТРИХА</h5>
<p class="MsoNormal" style="text-align: justify;">Обратимся к книге “Соло-гитара в стиле хэви-метал” Троя Стетины – выдающегося гитариста и преподавателя:</p>
<p class="MsoNormal" style="text-align: justify;">«Научиться играть переменным штрихом быстро и долго, постоянно переходя со струны на струну очень трудно, но оно того стоит. Послушай Ингви Мальмстина или Эла Ди Меолу и ты услышишь великолепные примеры такой игры…</p>
<p class="MsoNormal" style="text-align: justify;">…В следующих паттернах переход со струны на струну осуществляется с помощью внутреннего штриха. Это значит, что медиатор движется&nbsp; внутри пространства между струнами.</p>
<p class="MsoNormal" style="text-align: center;"><img src="/images/stories/altpicking/2_shtrih_1.jpg" border="0"></p>
<p class="MsoNormal">Противоположным этому является внешний штрих. Он используется в следующих примерах.</p>
<p class="MsoNormal" style="text-align: center;"><img src="/images/stories/altpicking/2_shtrih_2.jpg" border="0"></p>
<p class="MsoNormal" style="text-align: justify;">Если у тебя проблемы с каким-либо штрихом, придумай ходы и упражнения, которые помогут их решить»</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Есть небольшая путаница насчет названия типов штриха. В некоторых пособиях тот штрих, что у Стетины назван внутренним, называется внешним, а противоположный ему - внутренним. Хорошая новость заключается в том, что тебе ничего не придется придумывать самому. Прибереги фантазию и музыкальные идеи на будущее. Плохая новость – придется провести уйму времени, отрабатывая переменный штрих, иначе ты ничего не добьешься. А сейчас вспомним основные правила, которые необходимо соблюдать при игре переменным штрих.</p>
<p class="MsoNormal" style="margin-left: 18pt;">&nbsp;</p>
<p><strong>1. Играть только переменным штрихом.</strong><br><strong>2. Глушить струны ребром ладони.</strong><br><strong>3. Держать медиатор перпендикулярно струнам.</strong><br><strong>4. Играть медленно.</strong><br><strong>5. Играть только под метроном.</strong><br><strong>6. Не совершать лишних движений медиатором.</strong><br><strong>7. Держи пальцы левой руки на небольшом расстоянии от грифа.</strong></p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<p class="MsoListParagraphCxSpLast">И еще два правила:</p>
<p class="MsoListParagraphCxSpLast" style="text-align: justify;"><strong>8.</strong> При игре нужно обязательно чередовать игру с <strong style="line-height: 1.3em;">дисторшн</strong> и игру на <strong style="line-height: 1.3em;">чистом звуке</strong> (а лучше легком овердрайве). Поясняю. Играть на чистом звуке ты должен для того, чтобы слышать, что на самом деле делают твои руки. Очень легко увлечься игрой на перегрузе и не заметить, что ты играешь грязно.</p>
<p class="MsoListParagraphCxSpLast" style="text-align: justify;"><strong>9.</strong> Всегда старайся держать обе руки в расслабленном состоянии. Иначе ты будешь очень быстро уставать. А привыкнув держать руки в напряжении, переучиться будет очень и очень нелегко. Запомни, лишь научившись играть с расслабленными руками, то сможешь играть быстро!.</p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<p class="MsoListParagraphCxSpLast">И две небольших поправки к существующим пунктам:</p>
<p class="MsoListParagraphCxSpLast" style="text-align: justify;">Из <strong>третьего пункта</strong> следует, что медиатор следует держать перпендикулярно струнам. Но это лишь на начальных этапах тренировки. Вскоре ты поймешь, что, возможно, тебе удобней держать его под небольшим (или довольно большим - до сорока пяти градусов) наклоном, как делает это, например,&nbsp;<a href="/bio/item/104-andy-james" title="Энди Джеймс">Энди Джеймс</a>. Но это вскоре, а пока все же старайся держать его прямо.</p>
<p class="MsoNormal" style="text-align: justify;"><strong>Четвертый пункт</strong> говорит нам, что необходимо играть медленно, кроме того, как я уже говорил в прошлом уроке, следует чередовать игру <strong>на разных скоростях</strong>. Вычисли свою максимальную скорость, для этого выбери какое-нибудь несложное упражнение и, постепенно повышая скорость на метрономе, выясни, с какой максимальной скоростью ты можешь играть его чисто. После этого прими пятьдесят процентов от этой скорости за низкую скорость, шестьдесят - за среднюю, а семьдесят - за высокую. Так или иначе для тебя это будет медленно. Больше всего играй на низкой скорости, меньше на средней, минимальное время уделяй игре на высокой скорости.</p>
<p class="MsoNormal">&nbsp;</p>
<h5>УПРАЖНЕНИЯ</h5>
<p class="MsoNormal" style="text-align: justify;">Итак! Пришло время выучить несколько упражнений. Для начала два упражнения из видеошколы Майкла Анжэло “<span lang="EN-US">Speed</span><span lang="EN-US"> </span><span lang="EN-US">kills</span>”:</p>
<p class="MsoNormal" style="text-align: justify;"><em><a href="/images/audio/altpicking/Altpicking-2-1.mp3" title="MP3">Упражнение 1</a>. Это упражнение чертовски важно для дальнейшего развития техники переменного штриха. Ты должен <strong>играть его на всех пяти комбинациях струн</strong> (на шестой и пятой, на пятой и четвертой, на четвертой и третьей, на третьей и второй и, <strong>ГЛАВНОЕ</strong>, на второй и первой). Кроме того, ты непременно должен при помощи него отрабатывать <strong>различные типы штриха </strong>(внешний и внутренний). Просто один раз начни играть это упражнение с удара вниз (даунстрока), второй раз - с удара вверх (апстрока).</em></p>
<p class="MsoNormal" style="text-align: justify;"><img src="/images/stories/altpicking/2_upr_alternate_picking_1.jpg" border="0"></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-2.mp3" title="MP3">Упражнение 2</a>. Оно как ты видишь, является более сложной версией первого.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_2.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal">Теперь перейдем&nbsp; к упражнениям из книги Терри Сайрека &nbsp;“<span lang="EN-US">Shred</span><span lang="EN-US"> </span><span lang="EN-US">is</span><span lang="EN-US"> </span><span lang="EN-US">not</span><span lang="EN-US"> </span><span lang="EN-US">dead</span>”:</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-3.mp3" title="MP3">Упражнение 3</a>. Довольно длинное упражнение. Постарайся подобрать наиболее удобную для тебя пальцовку.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_3.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-4.mp3" title="MP3">Упражнение 4</a>. Продолжай играть последовательность, пока не дойдешь до нижних ладов (н</em><em style="line-height: 1.3em;">ижних по звучанию, т.е. самых широких)</em></p>
<p class="MsoNormal" style="text-align: justify;"><img src="/images/stories/altpicking/2_upr_alternate_picking_4.jpg" border="0"></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal">Упражнения из<span lang="EN-US"> “Speed mechanics for lead guitar”:</span></p>
<p class="MsoNormal" style="text-align: justify;"><em><a href="/images/audio/altpicking/Altpicking-2-5.mp3" title="MP3">Упражнение 5</a>. Это упражнение поможет тебе научиться перемещаться по грифу, а также напомнит о предыдущем уроке, так как на каждый такт здесь приходится всего по два перехода со струны на струну.</em></p>
<p class="MsoNormal" style="text-align: justify;"><img src="/images/stories/altpicking/2_upr_alternate_picking_7.jpg" border="0"></p>
@@METRONOME@@
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-6.mp3" title="MP3">Упражнение 6</a>. Как и первое, рекомендуется отрабатывать на всех комбинациях струн.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_5.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-7.mp3" title="MP3">Упражнение 7</a>.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_6.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Как ты мог заметить, во всех упражнениях было задействовано лишь две струны. Это и понятно – нужно идти от простого к сложному, а не наоборот. Еще раз напомню, что особое внимание стоит обратить на первое упражнение, так как переменный штрих на разных по толщине струнах отличается. Попытайся почувствовать гитару и понять в чем отличие.</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<h5 style="text-align: justify;">ПЕНТАТОНИКА</h5>
<p class="MsoNormal" style="text-align: justify;">Что такое пентатоника? Особое внимание я уделил ей в <a href="/improvisation/pentatonic" title="Пентатоника">разделе импровизация</a>. Пентатоника это гамма, состоящая всего из пяти нот. Несмотря на это обстоятельство, пентатоника весьма часто используется при построении соло. Многие известные роковые соляки были построены именно на пентатонике и звучали просто великолепно. Поэтому ты обязательно должен выучить пентатонику. К тому же она поможет тебе закрепить переход со струны струну, над которым ты работал в предыдущих упражнениях.</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Ниже ты видишь аппликатуру минорной пентатоники. Для начала нам хватит ее одной.</p>
<p class="MsoNormal" style="text-align: justify;"><img src="/images/stories/altpicking/pentatonika.jpg" border="0"></p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Подбери удобную для тебя пальцовку. Многие на двух верхних струнах используют третий палец. Некоторые - четвертый. Черной точкой обозначена тоника. Не буду вдаваться в теорию здесь. Скажу только, что тоника это нота, с которой начинается гамма. Как видишь, выучить пентатонику совсем не сложно.</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">Пришло время выполнить несколько упражнений, основанных на пентатонике. Трой Стетина в книге “<span lang="EN-US">Speed</span><span lang="EN-US"> </span><span lang="EN-US">Mechanics</span><span lang="EN-US"> </span><span lang="EN-US">For</span><span lang="EN-US"> </span><span lang="EN-US">Lead</span><span lang="EN-US"> </span><span lang="EN-US">Guitar</span>” выделил пять основных вариантов перехода со струны на струну. Попробуй определить, какой из них наиболее труден для тебя. Над ним и работай. Каждое упражнение начинай ударом вниз. Сначала поработай над первым тактом. Потом над последними двумя. В последнем такте тебе встретится несколько скачков через струну. Возможно, понадобится определенная доля упорства, чтобы научиться играть эти моменты чисто. Но ты должен это сделать!</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-8.mp3" title="MP3">Упражнение 8</a>.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_8.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal"><em><br></em></p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-9.mp3" title="MP3">Упражнение 9</a>.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_9.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-10.mp3" title="MP3">Упражнение 10</a>.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_10.jpg" border="0" style="border-style: initial; border-color: initial;"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-11.mp3" title="MP3">Упражнение 11</a>.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_11.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><em><a href="/images/audio/altpicking/Altpicking-2-12.mp3" title="MP3">Упражнение 12</a>.</em></p>
<p class="MsoNormal"><em><img src="/images/stories/altpicking/2_upr_alternate_picking_12.jpg" border="0"></em></p>
@@METRONOME@@
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal" style="text-align: justify;">И вновь о том как надо заниматься. Заниматься нужно регулярно. Даже небольшой перерыв в занятиях может отбросить тебя далеко назад. Время, которое нужно уделять гитаре, не ограничено. Здесь действует правило: "кашу маслом не испортишь". Однако, если чувствуешь сильную усталость в руках, или боль - немедленно прекращай занятия! Поврежденные связки техники еще никому не прибавляли. Не забывай о <a href="/beginner/warming-up" title="Разминка">разминке</a>. А после нее - учишь упражнение, включаешь метроном и вперед :)</p>
<p class="MsoNormal" style="text-align: justify;">Помни о правилах и вскоре выполнять их будет не сложнее, чем вдыхать свежий воздух. После того как будешь без проблем играть все упражнения данного урока на скорости 80 УВМ, можешь переходить к уроку <a href="/altpicking/altpickgamm" title="Переменный штрих - гаммы" style="line-height: 1.3em;">переменный штрих - гаммы</a>. Кроме этого я советую тебе, прежде чем идти дальше, выучить <a href="/practice/item/143-ac/dc-highway-to-hell-%D1%81%D0%BE%D0%BB%D0%BE" title="AC/DC - Highway to Hell">этот соляк</a>, а также уроки <a href="/tehnika/harmonics" title="Три способа взять флажолет">флажолеты</a>, <a href="/legatotechnique/legatofinger" title="Развитие независимости пальцев">развитие независимости пальцев</a>,&nbsp;<a href="/rythmguitar/rhytmmute" title="Глушение">глушение</a>. Желаю удачи!</p>
<p class="MsoNormal" style="text-align: justify;">&nbsp;</p>
<p class="MsoNormal" style="margin: 0.5em 0px; padding: 0px; border: 0px; outline: 0px; font-size: 13px; color: #555555; font-family: Arial, Helvetica, sans-serif; line-height: 23px; text-align: center;"><a href="/forum/viewtopic.php?f=2&amp;t=198" title="Уроки - переменный штрих" style="margin: 0px; padding: 0px; border: 0px; outline: 0px; background-color: transparent; color: #40678a;">ОБСУДИТЬ НА ФОРУМЕ</a></p>
<p class="MsoNormal" style="margin: 0.5em 0px; padding: 0px; border: 0px; outline: 0px; font-size: 13px; color: #555555; font-family: Arial, Helvetica, sans-serif; line-height: 23px; text-align: right;"><a href="/altpicking/altpickgamm" title="Переменный штрих - гаммы" style="margin: 0px; padding: 0px; border: 0px; outline: 0px; background-color: transparent; color: #40678a;">СЛЕДУЮЩИЙ УРОК &gt;&gt;</a></p>');