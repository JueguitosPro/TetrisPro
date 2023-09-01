using System.Collections;
using System.Collections.Generic;
using JueguitosPro.Models;
using JueguitosPro.Views;
using UnityEngine;

namespace JueguitosPro.Controllers
{
    public class SettingsController : ControllerBase<SettingsModel,SettingsView>
    {
        public SettingsController(SettingsModel model, SettingsView view) : base(model, view)
        {
        }
    }
}
