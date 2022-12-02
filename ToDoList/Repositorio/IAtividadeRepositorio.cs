using ToDoList.Models;
namespace ToDoList.Repositorio
{
    public interface IAtividadeRepositorio
    {
        AtividadesModel ListarPorId(int id);
        List<AtividadesModel> BuscarTodos();
        AtividadesModel Adicionar(AtividadesModel contato);

        AtividadesModel Atualizar(AtividadesModel contato);

        bool Apaga(int id);

    }
}
