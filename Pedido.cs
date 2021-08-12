using System;
using System.Collections.Generic;

class Pedido{
    private List<ItemPedido> itens = new List<ItemPedido>();

    public void IncluirPedido(string s, double d, int i){
        ItemPedido item = new ItemPedido();
        item.descricao = s;
        item.valor_unitario = d;
        item.quantidade = i;

        itens.Add(item);
    }

    public void ExibirPedido(){
        if(itens.Count > 0)
        {
            for(int i = 0; i < itens.Count; i++){
                Console.WriteLine("##############################################");
                Console.WriteLine($"Item {(i+1)}\nDescrição: {itens[i].descricao}\nValor: R${string.Format("{0:N2}",itens[i].valor_unitario)}\nQuantidade: {itens[i].quantidade}");
                Console.WriteLine("##############################################");
            }
        }
        else{
            Console.WriteLine("\nNão há itens neste pedido!\n");
        }
    }

    public double FinalizarPedido(){
        if (itens.Count > 0)
        {
            double count = 0;

            for(int i = 0; i < itens.Count; i++){
                count += (itens[i].valor_unitario * itens[i].quantidade);
            }

            return count;
        }

        else{
            return 0;
        }
    }
    
}