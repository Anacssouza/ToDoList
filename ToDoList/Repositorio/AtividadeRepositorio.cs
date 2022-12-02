using ToDoList.Controllers;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositorio
{
    public class AtividadeRepositorio : IAtividadeRepositorio
    {
        private readonly BancoContext _context;
        public AtividadeRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public AtividadesModel ListarPorId(int id)
        {
            return _context.Atividades.FirstOrDefault(x => x.Id == id);
        }

        public List<AtividadesModel> BuscarTodos()
        {
            return _context.Atividades.ToList();
        }

        public AtividadesModel Adicionar(AtividadesModel atividade)
        {
            _context.Atividades.Add(atividade);
            _context.SaveChanges();
            return atividade;
        }

        public AtividadesModel Atualizar(AtividadesModel atividade)
        {
            AtividadesModel atividadeDB = ListarPorId(atividade.Id);

            if (atividadeDB == null) throw new System.Exception("Houve um erro na atualização da atividade");

            atividadeDB.Tipo = atividade.Tipo;
            atividadeDB.Disciplina = atividade.Disciplina;
            atividadeDB.Data = atividade.Data;

            _context.Atividades.Update(atividadeDB);
            _context.SaveChanges();
            return atividadeDB;

        }

        public bool Apaga(int id)
        {
            AtividadesModel atividadeDB = ListarPorId(id);

            if (atividadeDB == null) throw new System.Exception("Houve um erro ao excluir a atividade");
            
            _context.Atividades.Remove(atividadeDB);
            _context.SaveChanges();

            return true;

        }
    }
}
