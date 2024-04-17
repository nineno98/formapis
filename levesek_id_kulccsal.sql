-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Ápr 17. 12:07
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `levesek`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `levesek`
--

CREATE TABLE `levesek` (
  `id` int(11) NOT NULL,
  `megnevezes` varchar(21) DEFAULT NULL,
  `kaloria` int(3) DEFAULT NULL,
  `feherje` decimal(3,2) DEFAULT NULL,
  `zsir` decimal(4,2) DEFAULT NULL,
  `szenhidrat` decimal(4,2) DEFAULT NULL,
  `hamu` decimal(2,1) DEFAULT NULL,
  `rost` decimal(5,1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `levesek`
--

INSERT INTO `levesek` (`id`, `megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost`) VALUES
(1, 'Raguleves', 325, 9.99, 23.40, 7.65, 6.2, 1.2),
(2, 'Rántott leves', 230, 3.70, 14.30, 21.50, 3.8, 0.3),
(3, 'Rizsleves', 151, 3.10, 7.90, 16.90, 4.1, 0.5),
(4, 'Sárgaborsókrémleves', 268, 9.99, 8.30, 36.90, 5.2, 0.8),
(5, 'Sóskaleves (tejfeles)', 252, 4.70, 11.30, 32.80, 5.3, 0.9),
(6, 'Spárgaleves', 249, 9.20, 11.40, 27.50, 5.0, 0.8),
(7, 'Szárazbableves', 318, 9.99, 12.10, 39.00, 5.5, 1.5),
(8, 'Zellerleves', 213, 4.90, 15.40, 13.70, 4.7, 0.8),
(9, 'Zöldbableves', 233, 6.20, 11.90, 25.20, 4.2, 1.2),
(10, 'Zöldborsóleves', 266, 9.20, 9.30, 34.70, 5.1, 2.2),
(11, 'Zöldségleves', 188, 5.40, 8.60, 22.30, 4.0, 1.0),
(12, 'Almaleves', 225, 4.20, 4.40, 42.10, 4.5, 1.0),
(13, 'Becsinált leves', 372, 9.99, 23.90, 23.10, 5.0, 0.8),
(14, 'Burgonyaleves', 306, 6.60, 11.40, 44.00, 3.8, 0.7),
(15, 'Csontleves zöldséggel', 69, 2.80, 0.40, 13.50, 4.0, 1.0),
(16, 'Gombaleves', 193, 4.40, 11.70, 17.40, 4.5, 0.2),
(17, 'Gulyásleves ', 336, 9.99, 11.10, 40.50, 4.8, 1.0),
(18, 'Halászlé (ponty)', 165, 9.99, 6.00, 3.30, 5.5, 0.0),
(19, 'Húsleves zöldséggel', 115, 9.99, 1.80, 13.70, 4.0, 1.0),
(20, 'Karalábéleves', 231, 6.30, 11.25, 26.10, 4.0, 0.9),
(21, 'Karfiolleves', 212, 6.65, 12.30, 18.90, 3.3, 1.0),
(22, 'Lebbencsleves', 242, 5.20, 10.70, 31.30, 4.5, 0.8),
(23, 'Meggyleves', 257, 5.17, 4.10, 49.90, 4.2, 0.4),
(24, 'Paradicsomleves', 255, 5.20, 8.00, 40.40, 4.1, 0.9),
(29, 'testleves', 0, 0.00, 0.00, 0.00, 0.0, 0.0),
(30, 'testleves2', 0, 0.00, 0.00, 0.00, 0.0, 3.0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `levesek`
--
ALTER TABLE `levesek`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `levesek`
--
ALTER TABLE `levesek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
