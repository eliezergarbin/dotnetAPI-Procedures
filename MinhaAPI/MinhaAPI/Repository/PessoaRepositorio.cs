using MinhaAPI.Dao;
using MinhaAPI.Model;

namespace MinhaAPI.Repository
{
    public class PessoaRepositorio
    {
        private readonly DaoPessoa _daoPessoa;
        public PessoaRepositorio()
        {
            _daoPessoa = new DaoPessoa();
        }

        public List<Pessoa> GetPessoas
        {
            get
            {
                return _daoPessoa.GetPessoas();
            }
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            _daoPessoa.InsertPessoa(pessoa);
        }
    }
}
