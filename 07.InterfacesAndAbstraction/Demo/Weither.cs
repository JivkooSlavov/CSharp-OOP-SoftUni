
using _03.InterfacesAndAbstraction.Kitchens;

namespace _03.InterfacesAndAbstraction
{
    class Waiter
    {
        private IKitchen kitchen;

        public Waiter()
        {
            kitchen = new ModernKitchen();
        }

        public void OrderFood(string food)
        {
            switch (food)
            {
                case "boloneze":
                    kitchen.PrepareSpaghettiBoloneze();
                    break;
                case "supa":
                    kitchen.PrepareMeatballsSoup();
                    break;
                case "steak":
                    kitchen.PrepareSteak();
                    break;
                default:
                    break;
            }
        }
    }
}