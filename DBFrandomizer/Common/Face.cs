﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFrandomizer.Common
{
    public static class Face
    {
        public static Dictionary<uint, string> Faces = new Dictionary<uint, string>
        {
            [0x00000cac] = "Pinich",
            [0x0000002c] = "Son Goku",
            [0x0000003c] = "Son Goku (Super Saiyen)",
            [0x0000004c] = "Son Goku (Super Saiyen 3)",
            [0x0000005c] = "Son Goku (Super Saiyen 4)",
            [0x0000009c] = "Son Gohan (Ado)",
            [0x000000bc] = "Son Gohan",
            [0x000000cc] = "Great Saiyaman 1",
            [0x0002802c] = "Son Goten",
            [0x0001410c] = "Vegeta",
            [0x0000010c] = "Vegeta (Super Saiyen)",
            [0x0000011c] = "Vegeta (Super Saiyen 3)",
            [0x0000012c] = "Vegeta (Super Saiyen 4)",
            [0x0000016c] = "Trunks",
            [0x0000017c] = "Trunks (Super Saiyen)",
            [0x0000013c] = "Trunks (Futur)",
            [0x0000014c] = "Trunks (Futur Super Saiyen)",
            [0x0000015c] = "Trunks (Futur Super Saiyen 3)",
            [0x0000023c] = "Gotenks",
            [0x0000024c] = "Gokents (Super Saiyen)",
            [0x0000025c] = "Gokents (Super Saiyen 3)",
            [0x0000028c] = "Gogeta (Super Saiyen)",
            [0x000002ac] = "Gogeta (Super Saiyen 4)",
            [0x0000027c] = "Vegeto",
            [0x0000018c] = "Piccolo",
            [0x0000019c] = "Krillin",
            [0x000001ac] = "Yamcha",
            [0x000001bc] = "Tenshinhan",
            [0x00000cdc] = "Yamhan",
            [0x000001cc] = "Chaozu",
            [0x000001dc] = "Mr. Satan",
            [0x000001ec] = "Videl",
            [0x000001fc] = "Great Saiyaman 2",
            [0x0000020c] = "Pan",
            [0x0000096c] = "Bra",
            [0x0000021c] = "Uub",
            [0x0002818c] = "Roi démon Piccolo",
            [0x000002cc] = "Raditz (Sans scouter)",
            [0x000142cc] = "Raditz (Avec scouter)",
            [0x000142dc] = "Nappa",
            [0x0000193c] = "Natz",
            [0x000002ec] = "Saibaman",
            [0x0000031c] = "Zarbon",
            [0x0000033c] = "Doria",
            [0x0000034c] = "Capitaine Ginyu",
            [0x0000035c] = "Guldo",
            [0x0000036c] = "Jeice",
            [0x0000037c] = "Burter",
            [0x0000038c] = "Recoome",
            [0x000003bc] = "Freezer",
            [0x00000c3c] = "Golden Freezer",
            [0x000003ec] = "Bardock",
            [0x0000073c] = "Bardock (Super Saiyen)",
            [0x000003fc] = "Gine",
            [0x0000041c] = "C-19",
            [0x0000042c] = "C-20",
            [0x0000043c] = "C-17",
            [0x0000044c] = "Super C-17",
            [0x0000045c] = "C-18",
            [0x0000046c] = "C-16",
            [0x000004ac] = "Cell Junior",
            [0x0000049c] = "Cell",
            [0x000004bc] = "Paikuhan",
            [0x000004cc] = "Buu : bienveillant",
            [0x0000050c] = "Buu : pur",
            [0x0000051c] = "Kaioshin",
            [0x0000052c] = "Kibito",
            [0x0000053c] = "Dabra",
            [0x0000061c] = "Baby",
            [0x0000064c] = "Li Shenron",
            [0x0000066c] = "Suu Shenron",
            [0x0000068c] = "Whis",
            [0x00000c8c] = "Vados",
            [0x0000078c] = "Cabe",
            [0x000007bc] = "Frost",
            [0x000007cc] = "Hit",
            [0x0000072c] = "Thalès",
            [0x0000058c] = "Cooler",
            [0x0000074c] = "Metal Cooler",
            [0x000005ac] = "Broly (Super Saiyen)",
            [0x000005bc] = "Broly (Super Saiyen 3)",
            [0x000005ec] = "Super Janemba",
            [0x000007ec] = "Towa",
            [0x000007fc] = "Mira",
            [0x000006ac] = "Aralé",
            [0x00000dcc] = "Pinita",
            [0x00000ddc] = "C-16 parfait",
            [0x00000dec] = "Celzer",
            [0x00000dfc] = "Damira",
            [0x00000e0c] = "C-1718",
            [0x00000e1c] = "Yamta",
            [0x00000e2c] = "Cooleezer",
            [0x00000e3c] = "Gokuhan",
            [0x00000c5c] = "Gogeta EX",
            [0x00000e5c] = "Great Saiyaman 12",
            [0x00000e6c] = "Piccohan",
            [0x00000e9c] = "Paikulo",
            [0x00000eac] = "Gorilin",
            [0x00000ebc] = "Krigohan",
            [0x00000ecc] = "Yamhan EX",
            [0x00000eec] = "Vegetrunks",
            [0x00000efc] = "Rappa",
            [0x00000f0c] = "Dobon",
            [0x00000f1c] = "Ginyuman",
            [0x00000f2c] = "Burce",
            [0x00000f3c] = "Reguldo",
            [0x00000f9c] = "Chaohan",
            [0x00000f5c] = "Godock",
            [0x00000f6c] = "C-1920",
            [0x00000f7c] = "C-1617",
            [0x00000f8c] = "Cell 17",
            [0x00000fac] = "Majin Satan",
            [0x00000fbc] = "Janembuu",
            [0x00000fcc] = "Karoly",
            [0x00000fdc] = "Aralé 18",
            [0x00000fec] = "Brapan",
            [0x00000ffc] = "Suu Goku",
            [0x0000101c] = "Towane",
            [0x0000102c] = "Ginyuzer",
            [0x0000103c] = "Towalé",
            [0x0000105c] = "Great Jaco",
            [0x0000106c] = "Thaditz",
            [0x0000107c] = "Pandel",
            [0x0000108c] = "Kibicollo",
            [0x0000109c] = "Kibirus",
            [0x000010ac] = "Roi démon Daccolo",
            [0x000010bc] = "Pirilin EX",
            [0x0000026c] = "Gotenks EX",
            [0x00000e8c] = "Gohanks EX",
            [0x00000cfc] = "Gohanks",
            [0x000010dc] = "Tranks",
            [0x00000d0c] = "Tranks",
            [0x000010cc] = "Le grand Herculeman",
            [0x000010ec] = "Son Goku (?)",
            [0x00000d5c] = "Trunks (Futur Dragon Ball Super)",
            [0x00000d6c] = "Son Goku Black",
            [0x0000110c] = "Trunks EX",
            [0x0000111c] = "Karoly Black",
            [0x000016cc] = "Étrangère 5",
            [0x00000d9c] = "Zamasu",
            [0x00000d8c] = "Zamasu fusionné",
            [0x0000112c] = "Gomas",
            [0x000012cc] = "Saiyen 1",
            [0x000012dc] = "Saiyen 2",
            [0x000012ec] = "Saiyen 3",
            [0x000012fc] = "Saiyen 4",
            [0x0000130c] = "Saiyen 5",
            [0x0000131c] = "Saiyen 6",
            [0x0000132c] = "Saiyen 7",
            [0x0000133c] = "Saiyen 8",
            [0x0000136c] = "Femme frange queue de cheval + ruban",
            [0x0000137c] = "Femme Chignon",
            [0x0000138c] = "Femme long",
            [0x0000139c] = "Femme carré (Trunks)",
            [0x000013ac] = "Femme Médium (Videl)",
            [0x000013bc] = "Femme court",
            [0x000013cc] = "Femme long (Volume)",
            [0x000013dc] = "Femme carré (C-18)",
            [0x0000140c] = "Namek 1",
            [0x0000141c] = "Namek 2",
            [0x0000142c] = "Namek 3",
            [0x0000143c] = "Namek 4",
            [0x000014ac] = "Extraterrestre 1",
            [0x000014bc] = "Extraterrestre 2",
            [0x000014cc] = "Extraterrestre 3",
            [0x000014dc] = "Extraterrestre 4",
            [0x000014ec] = "Extraterrestre 5",
            [0x000014fc] = "Extraterrestre 6",
            [0x0000150c] = "Extraterrestre 7",
            [0x0000151c] = "Extraterrestre 8",
            [0x0000154c] = "Femme Extraterrestre 1",
            [0x0000155c] = "Femme Extraterrestre 2",
            [0x0000156c] = "Femme Extraterrestre 3",
            [0x0000157c] = "Femme Extraterrestre 4",
            [0x0000158c] = "Femme Extraterrestre 5",
            [0x0000159c] = "Femme Extraterrestre 6",
            [0x000015ac] = "Femme Extraterrestre 7",
            [0x000015bc] = "Femme Extraterrestre 8",
            [0x000015ec] = "Étranger 1",
            [0x000015fc] = "Étranger 2",
            [0x0000160c] = "Étranger 3",
            [0x0000161c] = "Étranger 4",
            [0x0000162c] = "Étranger 5",
            [0x0000163c] = "Étranger 6",
            [0x0000164c] = "Étranger 7",
            [0x0000165c] = "Étranger 8",
            [0x0000168c] = "Étrangère 1",
            [0x0000169c] = "Étrangère 2",
            [0x000016ac] = "Étrangère 3",
            [0x000016bc] = "Étrangère 4",
            [0x000016dc] = "Étrangère 6",
            [0x000016ec] = "Étrangère 7",
            [0x000016fc] = "Étrangère 8",
        };
    }
}
