
use SkolaStranihJezika

-- popunjavanje tabele ucenik inicijalnim podatcima

INSERT INTO Ucenik (ime, prezime)
VALUES
('Ana', 'Markovic'),
('Petar', 'Ilic'),
('Jovana', 'Nikolic'),
('Milos', 'Petrovic'),
('Lena', 'Popovic'),
('Stefan', 'Jankovic'),
('Sara', 'Stankovic'),
('Dusan', 'Milovanovic'),
('Mila', 'Stojanovic'),
('Filip', 'Vukovic'),
('Ivana', 'Simic'),
('Nikola', 'Kovacevic'),
('Marija', 'Mihajlovic'),
('Aleksandar', 'Veselinovic'),
('Tijana', 'Pavlovic'),
('Marko', 'Markovic'),
('Jovana', 'Jovanovic'),
('Nikola', 'Nikolic'),
('Ana', 'Anic'),
('Petar', 'Petrovic'),
('Maja', 'Majic'),
('Filip', 'Filipovic'),
('Sanja', 'Savanovic'),
('Dusan', 'Dusanovic'),
('Milena', 'Milenkovic');


-- popunjavanje tabele kurs inicijalnim podatcima

INSERT INTO kurs (naziv, BrUceTre, BrUceMaks, straniJezik, AktivanDN)
VALUES 
('Engleski jezik A1', 7, 8, 'Engleski', 'D'),
('Francuski jezik A1', 6, 8, 'Francuski', 'D'),
('Nemački jezik A1', 5, 8, 'Nemački', 'D'),
('Italijanski jezik A1', 4, 8, 'Italijanski', 'N'),
('Španski jezik A1', 3, 8, 'Španski', 'D');

update kurs set brojucenikamaks=8


-- popunjavanje tabele pohadja inicijalnim podatcima
--delete pohadja
INSERT INTO Pohadja (id_kurs,id_ucenik)
VALUES 
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 4),
(3, 5),
(4, 6),
(4, 7),
(4, 8),
(5, 2),
(5, 6),
(5, 9),
(4, 10),
(3, 11),
(3, 12),
(2, 3),
(2, 13),
(2, 14),
(2, 15),
(1, 16),
(1, 17),
(3, 18),
(4, 19),
(5, 20),
(5, 21);