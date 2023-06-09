using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFrandomizer.Common
{
    public static class Top
    {
        public static Dictionary<uint, string> Tops = new Dictionary<uint, string>
        {
            [0x488001e8] = "Original Outfit (Male Saiyan)",
			[0x48a001e8] = "Original Outfit (Female Saiyan)",
			[0x000001e8] = "Earthling Clothes (Male)",
			[0x002001e8] = "Earthling Clothes (Female)",
			[0x008001e8] = "Saiyan Clothes (Male)",
			[0x00a001e8] = "Saiyan Clothes (Female)",
			[0x010001e8] = "Namekian Clothes",
			[0x038001e8] = "Offworlder Clothes (Male)",
			[0x03a001e8] = "Offworlder Clothes (Female)",
			[0x040001e8] = "Alien Clothes (Male)",
			[0x042001e8] = "Alien Clothes (Female)",
			[0x48000008] = "Goku (Adult)'s Turtle Style Gi",
			[0x48028008] = "Goku (Adult)'s Turtle Style Gi (Goku Mark)",
			[0x48154008] = "Goku (Adult)'s Gi",
			[0x48156008] = "Goku (Adult)'s Gi (No Mark)",
			[0x4803c008] = "Gohan (Young)'s Gi",
			[0x4803e008] = "Gohan (Teen)'s Gi",
			[0x48118048] = "Gohan (Teen)'s Jersey",
			[0x48040008] = "Trunks (Child)'s Gi",
			[0x48064008] = "Goten's Gi",
			[0x48078008] = "Krillin's Gi",
			[0x4807a008] = "Krillin's Gi (No Mark)",
			[0x4808c008] = "Yamcha's Gi",
			[0x4808e008] = "Yamcha's Gi (No Mark)",
			[0x480a0008] = "Tien's Clothes",
			[0x480b4008] = "Chiaotzu's Clothes",
			[0x480b6008] = "Chiaotzu's Clothes (No Mark)",
			[0x480c8008] = "Hercule's Clothes",
			[0x480ca008] = "Hercule's Clothes (No Cape or Belt)",
			[0x480dc008] = "Uub's Clothes",
			[0x48000098] = "Super Uub's Clothes",
			[0x480f0008] = "Vegito's Clothes",
			[0x48104008] = "Goku (GT)'s Clothes",
			[0x4812c008] = "Goku (Young)'s Clothes",
			[0x4812e008] = "Goku (Young)'s Clothes (No Mark)",
			[0x4816a008] = "Pinich's Clothes",
			[0x48000018] = "Vegeta's Old Battle Suit",
			[0x48014018] = "Vegeta's Training Suit",
			[0x4812c018] = "Vegeta's Battle Suit",
			[0x4812e018] = "Vegeta's Battle Suit (No Mark)",
			[0x48028018] = "Nappa's Battle Suit",
			[0x4802a018] = "Raditz's Battle Suit",
			[0x48050018] = "Zarbon's Battle Suit",
			[0x48064018] = "Dodoria's Battle Suit",
			[0x48078018] = "Ginyu's Battle Suit",
			[0x4807a018] = "Ginyu's Battle Suit (No Mark)",
			[0x4808c018] = "Jeice's Battle Suit",
			[0x4808e018] = "Jeice's Battle Suit (No Mark)",
			[0x48090018] = "Guldo's Battle Suit",
			[0x48092018] = "Guldo's Battle Suit (No Mark)",
			[0x480a0018] = "Burter's Battle Suit",
			[0x480a2018] = "Burter's Battle Suit (No Mark)",
			[0x480b4018] = "Recoome's Battle Suit",
			[0x480b6018] = "Recoome's Battle Suit (No Mark)",
			[0x480c8018] = "Bardock's Battle Suit",
			[0x482dc018] = "Gine's Battle Suit",
			[0x48118018] = "Turles' Battle Suit",
			[0x48140018] = "Cabbe's Battle Suit",
			[0x48014038] = "Piccolo's Clothes",
			[0x48000038] = "Piccolo's Clothes (No Cloak)",
			[0x4803c038] = "Demon King Piccolo's Clothes",
			[0x4803e038] = "Demon King Piccolo's Clothes (No Mark)",
			[0x48050038] = "Nail's Clothes",
			[0x48000048] = "Trunks (Future)'s Clothes",
			[0x48002048] = "Trunks (Future)'s Clothes (No Mark)",
			[0x48214048] = "Videl's Clothes",
			[0x48228048] = "Pan's Clothes",
			[0x4b850048] = "Tapion's Clothes",
			[0x48064048] = "Arale's Clothes",
			[0x482a0048] = "Mai's Clothes",
			[0x480b4048] = "Student Blazer (Male)",
			[0x482b4048] = "Student Blazer (Female)",
			[0x48050068] = "Android 16's Clothes",
			[0x48052068] = "Android 16's Clothes (No Mark)",
			[0x48028068] = "Android 17's Clothes",
			[0x4802a068] = "Android 17's Clothes (No Mark)",
			[0x4823c068] = "Android 18's Clothes",
			[0x4823e068] = "Android 18's Clothes (No Mark)",
			[0x48000068] = "Android 19's Clothes",
			[0x48014068] = "Android 20's Clothes",
			[0x48064068] = "Super 17's Clothes",
			[0x48014098] = "Majin Buu - Good's Clothes",
			[0x480000a8] = "East Supreme Kai's Clothes",
			[0x480140a8] = "Beerus' Clothes",
			[0x480280a8] = "Whis' Clothes",
			[0x4803c0a8] = "Pikkon's Clothes",
			[0x4b8500a8] = "Kibito Kai's Clothes",
			[0x480640a8] = "Dabura's Clothes",
			[0x480780a8] = "Champa's Clothes",
			[0x4828c0a8] = "Vado's Clothes",
			[0x480c80a8] = "Mira's Clothes",
			[0x480ca0a8] = "Mira's Clothes (No Mark)",
			[0x480a00a8] = "Hit's Clothes",
			[0x480280c8] = "Baby's Clothes",
			[0x4803c0e8] = "Jaco's Clothes",
			[0x4803e0e8] = "Jaco's Clothes (No Mark)",
			[0x48104048] = "Announcer's Clothes (Male)",
			[0x48304048] = "Announcer's Clothes (Female)",
			[0x480c8048] = "Pilot Suit",
			[0x480dc048] = "Overralls",
			[0x48000028] = "Broly's Clothes",
			[0x48050028] = "Bora's Clothes",
			[0x48064028] = "Tien's Gi (No Sleeves)",
			[0x48800058] = "Great Saiyaman Outfit",
			[0x48200058] = "Great Saiyaman 2 Outfit",
			[0x48028098] = "Majin Buu - Pure's Clothes",
			[0x4828c048] = "Bulla's Clothes",
			[0x482b40a8] = "Towa's Clothes",
			[0x4832c048] = "Tight's Clothes",
			[0x48340048] = "Bulma's Clothes",
			[0x48278048] = "Chi-Chi's Clothes",
			[0x48000078] = "Frieza Suit",
			[0x48050078] = "Cooler Suit",
			[0x4808c078] = "Metal Cooler Suit",
			[0x480dc078] = "Golden Frieza Suit",
			[0x480f0078] = "Frost Suit",
			[0x48050088] = "Cell Suit",
			[0x48064088] = "Cell Jr. Suit",
			[0x480140d8] = "Omega Shenron Suit",
			[0x480000d8] = "Nuova Shenron Suit",
			[0x480000e8] = "Saibaman Suit",
			[0x480140e8] = "Super Janemba Suit",
			[0x480640e8] = "Botamo Suit",
			[0x480780e8] = "Magetta Suit",
			[0x480500e8] = "Monaka Suit",
			[0x4817c008] = "Goku Black's Clothes",
			[0x48154048] = "Trunks (Super)'s Clothes",
			[0x481180a8] = "Zamas's Clothes",
			[0x481040a8] = "Fused Zamas's Clothes",
			[0x480f2168] = "EX Gohanks's Clothes",
			[0x4816a168] = "Vegenks's Clothes",
			[0x481f6168] = "Barlot's Clothes",
			[0x4807a178] = "Karoly's Clothes",
			[0x480b6178] = "Nuova Goku's Clothes",
			[0x00800168] = "Pinita's Battle Suit (Male Only)",
			[0x02014168] = "Perfect 16 Suit (Male Only)",
			[0x02828168] = "Cellza Suit",
			[0x0383c168] = "Damira's Clothes (Male Only)",
			[0x00050168] = "Android 1718 (Male Only)",
			[0x00864168] = "Yamta's Clothes (Male Only)",
			[0x01878168] = "Coolieza Suit (Male Only)",
			[0x0088c168] = "Coohan's Clothes (Male Only)",
			[0x008a0168] = "EX Gogeta's Clothes (Male Only)",
			[0x008b4168] = "Great Saiyaman 12's Battle Suit (Male Only)",
			[0x010c8168] = "Kallohan Body (Male Only)",
			[0x008dc168] = "EX Gotenks's Clothes",
			[0x01104168] = "Picohan's Clothes (Male Only)",
			[0x00918168] = "Gorillin's Clothes (Male Only)",
			[0x0092c168] = "Krigohan's Clothes (Male Only)",
			[0x00140168] = "EX Yamhan's Clothes (Male Only)",
			[0x00154168] = "Chialdo's Clothes",
			[0x04190168] = "Dodobon's Battle Suit (Male Only)",
			[0x041a4168] = "Ginyuman's Clothes (Male Only)",
			[0x041b8168] = "Burce's Battle Suit (Male Only)",
			[0x041cc168] = "Reguldo's Battle Suit (Male Only)",
			[0x001e0168] = "Chiaohan's Clothes (Male Only)",
			[0x02000178] = "Android 1920's Clothes",
			[0x00028178] = "Cell 17's Clothes (Male Only)",
			[0x0003c178] = "Chiaoman's Clothes",
			[0x03064178] = "Janembu Suit",
			[0x00878178] = "Karoly's Body (Male Only)",
			[0x0028c178] = "Arale 18's Clothes (Female Only)",
			[0x002a0178] = "Brapan's Clothes (Female Only)",
			[0x000c8178] = "Jacunk's Clothes",
			[0x002dc178] = "Towane's Battle Suit",
			[0x040f0178] = "Ginyuza's Battle Suit (Male Only)",
			[0x00304178] = "Towale's Clothes (Female Only)",
			[0x03918178] = "Whiru's Clothes & Body (Male Only)",
			[0x0012c178] = "Great Jaco's Clothes (Male Only)",
			[0x00354178] = "Pandel's Clothes (Female Only)",
			[0x00168178] = "Kibicollo Kai's Clothes (Male Only)",
			[0x0397c178] = "Kibeer Kai's Clothes (Male Only)",
			[0x01190178] = "Daccolo's Clothes (Male Only)",
			[0x011a4178] = "EX Pirillin's Clothes (Male Only)",
			[0x001b8178] = "Great Satanman's Clothes (Male Only)",
			[0x001cc178] = "Tank's Clothes (Male Only)",
			[0x001e0178] = "Goru's Clothes (Male Only)",
			[0x00000188] = "EX Trunk's Clothes",
			[0x00014188] = "Black Karoly's Clothes (Male Only)",
			[0x00028188] = "Gomasu's Clothes",
			[0x008000b8] = "Goku SSJ4's Fur",
			[0x008140b8] = "Vegeta SSJ4's Fur",
			[0x008000f8] = "Gogeta's Clothes",
			[0x008140f8] = "Gogeta SSJ4's Clothes",
			[0x00000328] = "Metamoran Fusion Clothes",
			[0x01000328] = "Metamoran Fusion Clothes (Namekian?)",
			[0x00000348] = "EX Fusion's Clothes 1 (Male Earthling)",
			[0x00800348] = "EX Fusion's Clothes 2 (Male Saiyan)",
			[0x01000348] = "EX Fusion's Clothes 3 (Namekian)",
			[0x03800348] = "EX Fusion's Clothes 4 (Male Offworlder)",
			[0x04000348] = "EX Fusion's Clothes 5 (Male Alien)",
			[0x00200348] = "EX Fusion's Clothes 1 (Female Earthling)",
			[0x00a00348] = "EX Fusion's Clothes 2 (Female Saiyan)",
			[0x03a00348] = "EX Fusion's Clothes 3 (Female Offworlder)",
			[0x04200348] = "EX Fusion's Clothes 4 (Female Alien)",
        };
    }
}
