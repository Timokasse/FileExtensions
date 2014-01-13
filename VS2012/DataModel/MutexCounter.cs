using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel {
    public class MutexCounter {
        private int _value;

        public int Value {
            get { return _value; }
        }

        private int _maxValue;

        public int MaxValue {
            get { return _maxValue; }
        }

        public static MutexCounter operator --(MutexCounter mc) {
            lock (mc) {
                mc._value--;
            }
            return mc;
        }

        public static MutexCounter operator ++(MutexCounter mc) {
            lock (mc) {
                mc._value++;
                if (mc._maxValue < mc._value) {
                    mc._maxValue = mc._value;
                }
            }
            return mc;
        }

        public MutexCounter() {
            _value = 0;
            _maxValue = 0;
        }

        public override string ToString() {
            return String.Format("{0}/{1}", _value, _maxValue);
        }

    }
}
