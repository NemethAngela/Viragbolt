CREATE TABLE IF NOT EXISTS kategoriak (
    id INTEGER PRIMARY KEY,
    nev TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS aruk (
    id INTEGER PRIMARY KEY,
    nev TEXT NOT NULL,
    kategoriaId INTEGER,
    leiras TEXT,
    keszlet INTEGER,
    ar INTEGER,
    kepUrl TEXT,
    FOREIGN KEY(kategoriaId) REFERENCES kategoriak(id)
);

ALTER TABLE `kategoriak`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT;
  
ALTER TABLE `aruk`
MODIFY `id` int(32) NOT NULL AUTO_INCREMENT;


INSERT INTO kategoriak (id, nev) VALUES
(1, 'virág'),
(2, 'örökzöld');


INSERT INTO aruk (id, nev, kategoriaId, leiras, keszlet, ar, kepUrl) VALUES 
(1, 'Rózsa', 1, 'A rózsa a rózsafélék (Rosaceae) családjába tartozó növények közös neve.', 10, 400, 'https://afonyatrend.hu/wp-content/uploads/2022/01/Termekfotok-20210517-9-e1641733366990.jpg'),
(2, 'Tulipán', 1, 'A tulipán (Tulipa) a liliomfélék (Liliaceae) családjába tartozó növények nemzetsége. A tulipánok a törökországi Szökevény-hegységben őshonosak.', 50, 200, 'https://www.megyeriszabolcskerteszete.hu/minden_amit_a_tulipanrol_tudni_erdemes')

