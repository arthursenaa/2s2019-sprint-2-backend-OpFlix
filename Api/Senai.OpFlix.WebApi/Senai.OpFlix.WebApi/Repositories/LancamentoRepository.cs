using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        //-------------------//
        private string StringConexao = "Data Source=localhost;Initial Catalog=T_InLock;User Id=sa;Pwd=132;";

        opflixContext ctx = new opflixContext();
        //-------------------//


        public List<Lancamento> ListarLancamentos()
        {
            return ctx.Lancamento.Include(x => x.IdGeneroNavigation).ToList();
        }



        public Lancamento ListarId(int id)
        {
            return ctx.Lancamento.FirstOrDefault(x => x.IdLancamentos == id);
        }



        public void AtualizarLancamento(Lancamento lancamento)
        {
            Lancamento LancamentoBuscado = ctx.Lancamento.FirstOrDefault(x => x.IdLancamentos == lancamento.IdLancamentos);
            LancamentoBuscado.Nome = lancamento.Nome;
            ctx.Lancamento.Update(LancamentoBuscado);
            ctx.SaveChanges();
        }



        public void CadastrarLancamento(Lancamento lancamento)
        {
            ctx.Lancamento.Add(lancamento);
            ctx.SaveChanges();
        }



        public void DeletarLancamento(int id)
        {
            Lancamento lancamento = ctx.Lancamento.Find(id);
            ctx.Lancamento.Remove(lancamento);
            ctx.SaveChanges();
        }


    }
}
