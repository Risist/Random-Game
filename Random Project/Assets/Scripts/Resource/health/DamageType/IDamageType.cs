using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IDamageType
{
    void ChangeHealth(HealthController hpC, GameObject causer);
	float toFloat();
}

