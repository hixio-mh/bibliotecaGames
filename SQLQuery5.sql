insert into generos values('Esporte');
insert into generos values('Terror');
insert into generos values('Aventura');
insert into generos values('1ª Pessoa');
insert into generos values('RPG');
insert into generos values('Infantil');
Select * from generos;

insert into editores values('EA GAMES');
insert into editores values('EDITOR 2');

Select * from editores;

insert into jogos values('FIFA 16', 200, '01-01-2017', 1, 1, 'fifa16.jpg');
insert into jogos values('GTA', 200, '01-01-2017', 1, 1, 'gta5.png');
insert into jogos values('STREET FIGTHER', 200, '01-01-2017', 1, 1, 'StrF.jpg');
insert into jogos values('COUNTER STRIKE', 200, '01-01-2017', 1, 1, 'csgo.jpg');
insert into jogos values('LEAGUE OF LEGENDS', 200, '01-01-2017', 1, 1, 'Lol.jpg');
Delete from jogos where titulo = 'GTA';