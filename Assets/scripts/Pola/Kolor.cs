using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pole
{

    bool pole { get; set; }
    bool green { get; set; }
    bool pole2 { get; set; }
    bool enemy { get; set; }
    bool enemy2 { get; set; }
    bool ally { get; set; }
    bool pom { get; set; }

    bool ult3 { get; set; }
    int idGracza { get; set; }
    int id { get; set; }
    int dmg { get; set; }

    bool round { get; set; }
    bool ult2 { get; set; }

    bool ult { get; set; }
    void Kolor();
}
