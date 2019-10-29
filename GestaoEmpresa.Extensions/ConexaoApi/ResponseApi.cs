using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Extensions.ConexaoApi
{
    public class ResponseApi<TResult>
    {
        /// <summary>
		/// Método construtor da classe
		/// </summary>
		public ResponseApi()
        {
            //InformationResult = new InformationResult();
            errors = new List<ResultMessage>();
            warnings = new List<ResultMessage>();
            informations = new List<ResultMessage>();
        }

        /// <summary>
        ///     Retorna uma instância da classe
        /// </summary>
        public static ResponseApi<TResult> Instance
        {
            get { return Activator.CreateInstance<ResponseApi<TResult>>(); }
        }

        /// <summary>
        ///     Mensagens de erro
        /// </summary>
        //public InformationResult InformationResult { get; set; }

        public IList<ResultMessage> errors { get; set; }
        public IList<ResultMessage> warnings { get; set; }
        public IList<ResultMessage> informations { get; set; }

        /// <summary>
        ///     Resultado
        /// </summary>
        public TResult result { get; set; }

        /// <summary>
        ///     Adiciona uma mensagem de erro à classe
        /// </summary>
        /// <lParamContribuicao name="pMessage">Texto da mensagem</lParamContribuicao>
        /// <lParamContribuicao name="pCode">Código da mensagem (Default = 500)</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> AddError(string pMessage, int pCode = 500)
        {
            errors.Add(new ResultMessage { code = pCode, msg = pMessage });

            return this;
        }

        /// <summary>
        ///     Adiciona uma mensagem de alerta à classe
        /// </summary>
        /// <lParamContribuicao name="pMessage">Texto da mensagem</lParamContribuicao>
        /// <lParamContribuicao name="pCode">Código da mensagem (Default = 100)</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> AddWarning(string pMessage, int pCode = 100)
        {
            warnings.Add(new ResultMessage { code = pCode, msg = pMessage });

            return this;
        }

        /// <summary>
        ///     Adiciona uma mensagem de informação à classe
        /// </summary>
        /// <lParamContribuicao name="pMessage">Texto da mensagem</lParamContribuicao>
        /// <lParamContribuicao name="pCode">Código da mensagem (Default = 200)</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> AddInfo(string pMessage, int pCode = 200)
        {
            informations.Add(new ResultMessage { code = pCode, msg = pMessage });

            return this;
        }

        /// <summary>
        ///     Adiciona uma coleção de mesnagens de erro à classe
        /// </summary>
        /// <lParamContribuicao name="errors">Lista de mensagens</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> AddErrors(IList<ResultMessage> errors)
        {
            foreach (var msg in errors)
                AddError(msg.msg, msg.code);

            //if (InformationResult.Errors == null)
            //	InformationResult.Errors = new List<ResultMessage>();
            //foreach (var msg in errors)
            //{
            //	InformationResult.Errors.Add(msg);
            //}
            return this;
        }

        /// <summary>
        ///     Adiciona uma coleção de mesnagens de alerta à classe
        /// </summary>
        /// <lParamContribuicao name="warnings">Lista de mensagens</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> AddWarnings(IList<ResultMessage> warnings)
        {
            foreach (var msg in warnings)
                AddWarning(msg.msg, msg.code);

            //if (InformationResult.Warnings == null)
            //	InformationResult.Warnings = new List<ResultMessage>();
            //foreach (var msg in warnings)
            //{
            //	InformationResult.Warnings.Add(msg);
            //}
            return this;
        }

        /// <summary>
        ///     Adiciona uma coleção de mesnagens de informação à classe
        /// </summary>
        /// <lParamContribuicao name="infos">Lista de mensagens</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> AddInfos(IList<ResultMessage> infos)
        {
            foreach (var msg in infos)
                AddInfo(msg.msg, msg.code);

            return this;
        }

        /// <summary>
        ///     Atribui um resultado à classe
        /// </summary>
        /// <lParamContribuicao name="pResult">Resultado</lParamContribuicao>
        /// <returns>Classe de retorno de T</returns>
        public ResponseApi<TResult> SetResult(TResult pResult)
        {
            result = pResult;
            return this;
        }
    }
    /// <summary>
    ///     Mensagens de Retorno
    /// </summary>
    public class ResultMessage
    {
        /// <summary>
        ///     Codigo da Mensagem
        /// </summary>
        public int code { get; set; }

        /// <summary>
        ///     Texto descritivo da mensagem
        /// </summary>
        public string msg { get; set; }
    }
}
