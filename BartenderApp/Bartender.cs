using System;

namespace BartenderApp
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public Bartender(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void AskForDrink()
        {
            _outputProvider("What drink do you want? (beer, soda)");

            var drink = _inputProvider() ?? string.Empty;

            // if (drink.Equals("beer")) ServeBeer() etc..:
            switch (drink)
            {
                case "beer":
                    ServeBeer();
                    break;
                case "soda":
                    ServeSoda();
                    break;
                default:
                    UnvailableDrink(drink);
                    break;
            }
        }

        private void UnvailableDrink(string drink)
        {
            _outputProvider($"Sorry friend, we don't do {drink} here.");
        }

        private void ServeSoda()
        {
            _outputProvider("Here's you pop, mate");
        }

        private void ServeBeer()
        {
            _outputProvider("Well, how old are you?");
            if (!int.TryParse(_inputProvider(), out var age))
            {
                HandleInvalidInpput();
                // By adding the return keyword here we can remove the else keyword below:
                return;
            }
            HandleBeerAgeCheck(age);

        }

        private void HandleBeerAgeCheck(int age)
        {
            if (age >= 18)
            {
                _outputProvider("Here's your cold pint, enjoy! It's on the house.");
                // By adding the return keyword here we can remove the else keyword below:
                return;
            }
            _outputProvider("You aren't old enough to order that yet.");

        }

        private void HandleInvalidInpput()
        {
            _outputProvider("Could not parse the age provided");
        }
    }
}