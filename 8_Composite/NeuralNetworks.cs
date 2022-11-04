using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Composite
{
    public class NeuralNetworks
    {
        public static void Test()
        {
            var neuron1 = new Neuron(){Value = 20};
            var neuron2 = new Neuron(){Value = 30};
            neuron1.ConnectTo(neuron2);
            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
    internal static class ExtensionMethods 
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if(ReferenceEquals(self, other)) return;
            foreach (var from in self)
            {
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }
    internal class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In = new List<Neuron>();
        public List<Neuron> Out = new List<Neuron>();
        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class NeuronLayer : Collection<Neuron>
    {

    }
}