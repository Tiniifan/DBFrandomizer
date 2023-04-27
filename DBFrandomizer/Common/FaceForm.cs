using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFrandomizer.Common
{
    public static class FaceForm
    {
        public static Dictionary<uint, string> FaceForms = new Dictionary<uint, string>
        {
            [0x00028003] = "Gotenks",
            [0x00000003] = "Son Goku",
            [0x48000003] = "Vegeto",
            [0x01000033] = "Piccolo",
            [0x00014003] = "Krilin",
            [0x00050003] = "Uub",
            [0x040000e3] = "Saibaman",
            [0x040140f3] = "Zarbon",
            [0x0c0500f3] = "Guldo",
            [0x01800073] = "Freezer",
            [0x018a0073] = "Golden Freezer",
            [0x08000003] = "Bardock",
            [0x02800083] = "Cell",
            [0x038000a3] = "Kibito",
            [0x038640a3] = "Dabra",
            [0x0388c0a3] = "Hit",
            [0x01828073] = "Cooler",
            [0x08000013] = "Broly",
            [0x040140e3] = "Super Janemba",
            [0x03aa00a3] = "Towa",
            [0x038b40a3] = "Mira",
            [0x0383c163] = "Damira",
            [0x02828173] = "Cell 17",
            [0x40000003] = "Son Goku Black",
            [0x039180a3] = "Zamasu",
            [0x039040a3] = "Zamasu fusionné",
            [0x280001ea] = "Homme 1",
            [0x000001ea] = "Homme 2",
            [0x180001ea] = "Homme 3",
            [0x282001fa] = "Femme 1",
            [0x002001fa] = "Femme 2",
            [0x0100020a] = "Namek 1",
            [0x0101420a] = "Namek 2",
            [0x0380023a] = "Étranger (Potara)",
            [0x0381423a] = "Étranger (Buu)",
            [0x2ba0024a] = "Étrangère (Potara)",
            [0x03a1424a] = "Étrangère (Buu)",
            [0x0400021a] = "Extraterrestre (Homme)",
            [0x0420022a] = "Extraterrestre (Femme)",
        };
    }
}
