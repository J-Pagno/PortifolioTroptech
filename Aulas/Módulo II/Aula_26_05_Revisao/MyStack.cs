using System;

namespace Aula_26_05
{
    public class MyStack
    {
        private string[] _stackSlots = { };

        public int GetLenghtOfMyStack
        {
            get { return _stackSlots.Length; }
        }

        public string GetFirstItemStack
        {
            get
            {
                return (
                    (_stackSlots.Length > 0)
                        ? _stackSlots[_stackSlots.Length - 1].ToString()
                        : "Nenhum item na pilha"
                );
            }
        }

        public void StackIn(string newValue)
        {
            int arrayLenght = (_stackSlots.Length > 0) ? (_stackSlots.Length + 1) : 1;

            string[] newItem = new string[arrayLenght];
            if (_stackSlots.Length > 0)
                for (int i = 0; i < arrayLenght - 1; i++)
                    newItem[i] = _stackSlots[i];

            newItem[arrayLenght - 1] = newValue;

            _stackSlots = newItem;
        }

        public string StackOut()
        {
            int arrayLenght =
                (_stackSlots.Length == 0) ? _stackSlots.Length : _stackSlots.Length - 1;

            string[] newItem = new string[arrayLenght];

            if (arrayLenght > 0)
                for (int i = 0; i < arrayLenght; i--)
                    newItem[i - 1] = _stackSlots[i];

            _stackSlots = newItem;

            return (_stackSlots.Length > 0)
              ? _stackSlots[_stackSlots.Length - 1].ToString()
              : "Pilha vazia";
        }

        public void ClearMyStack()
        {
            _stackSlots = new string[0];
        }

        public bool ContainInMyStack(string value)
        {
            foreach (var item in _stackSlots)
            {
                if (item.ToString() == value)
                    return true;
            }
            return false;
        }
    }
}
