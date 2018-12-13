using System;
using Open.Core;
using Open.Domain.Museum;
using Open.Facade.Common;
namespace Open.Facade.Museum
{
    public class MusealViewFactory
    {
        public static InventoryView CreateInventory(Inventory o) {
            var v = new InventoryView();
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            v.Employee = o?.Data?.Employee;
            return v;
        }
        public static MusealView CreateMuseal(Museal o)
        {
            var v = new MusealView();
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            setMusealCommonValues(v, o?.Data?.Author, o?.Data?.Designation,
                o?.Data?.Info, o?.Data?.DamagesBefore, o?.Data?.DefaultLocation, o?.Data?.CurrentLocation,
                o?.Data?.StateBefore);
            return v;
        }

        public static InventoryMusealView CreateInventoryMuseal(Museal o, InventoryMuseal i)
        {
            var v = new InventoryMusealView();
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            setMusealCommonValues(v, o?.Data?.Author, o?.Data?.Designation,
                o?.Data?.Info, o?.Data?.DamagesBefore, o?.Data?.DefaultLocation, o?.Data?.CurrentLocation, 
                o?.Data?.StateBefore);
            v.IsChecked = i?.Data?.IsChecked ?? false;
            v.IsFound = i?.Data?.IsFound ?? false;
            v.HasStateChanged = i?.Data?.HasStateChanged ?? false;
            v.StateNow = i?.Data?.State ?? MusealState.Unspecified;
            v.DamagesNow = i?.Data?.Damages;
            v.MusealID = i?.Data?.MusealID;
            v.InventoryID = i?.Data?.InventoryID;
            return v;
        }

        private static void setCommonValues(EntityView model, string id, 
            DateTime? validFrom, DateTime? validTo)
        {
            model.ID = id;
            model.ValidFrom = setNullIfExtremum(validFrom ?? DateTime.MinValue);
            model.ValidTo = setNullIfExtremum(validTo ?? DateTime.MaxValue);

        }

        private static void setMusealCommonValues(MusealView model, 
            string author, string designation, string info, string damagesBefore,
            string defaultLocation, string currentLocation, 
            MusealState? state = MusealState.Unspecified) {
            model.Author = author;
            model.Designation = designation;
            model.Info = info;
            model.DamagesBefore = damagesBefore;
            model.DefaultLocation = defaultLocation;
            model.CurrentLocation = currentLocation;
            model.StateBefore = state ?? MusealState.Unspecified;
        }
        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}
