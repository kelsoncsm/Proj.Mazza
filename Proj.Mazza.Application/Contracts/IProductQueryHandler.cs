using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proj.Mazza.Application.DTOs;


namespace Proj.Mazza.Application.Contracts
{
    public interface IProductQueryHandler
    {
        //Task<ProductDTO> GetHolderById(Guid id);
        //Task<IEnumerable<ProductDTO>> GetProductsByID(Guid id);
        //Task<IEnumerable<ProductGridDTO>> GetAllHolder(GridSearch objetoPesquisa);
        //Task<IEnumerable<ProductDTO>> GetProductsByPrincipal(Guid principalId);
        //Task<IEnumerable<ArchiveDTO>> GetArchiveByHolder(Guid holderId, int? exceptStatus = null);
        //Task<IEnumerable<DebtDTO>> GetAllDebtsByHolder(Guid holderId);
        //Task<IEnumerable<PatrimonyDTO>> GetAllPatrimoniesByHolder(Guid holderId);
        //Task<IEnumerable<IncomeDTO>> GetAllIncomesByHolder(Guid holderId);
        //Task<IEnumerable<ProfessionDTO>> GetAllProfessionsByHolder(Guid holderId);
        //Task<IEnumerable<ProfessionDTO>> GetOutherSourcesIncomeByHolder(Guid holderId);
        //Task<ProfessionDTO> GetProfessionByHolder(Guid holderId);
        //Task<IEnumerable<DocumentDTO>> GetAllDocumentsByHolder(Guid holderId);

        //Task<ProfessionDTO> GetProfessionById(int id);
        //Task<bool> CheckCPFAlreadyRegistered(string cpf,string flag);
        //Task<bool> CheckCelPhoneAlreadyRegistered(string cpf, string flag);
        //Task<bool> CheckEmailAlreadyRegistered(string cpf, string flag);
        //Task<ProductDTO> GetHolderByCPF(string cpf,string flag);
        //Task<IEnumerable<ProductCadastroDTO>> GetHolderRegister(string cpf, string flag);
        //Task<IEnumerable<DocumentGridDTO>> GetAllDocumentsByCPF(string cpf, string flag);
        //Task<IEnumerable<ArchiveGridDTO>> GetAllArquivesByCpfAndType(string cpf, int type, int registrationStatus, string flag);
        //Task<IEnumerable<ArchiveGridDTO>> GetArquivesByCpfAndType(string cpf, int type, int registrationStatus, string flag);
        //Task<CityDTO> GetCityById(int id);
        //Task<IEnumerable<CityDTO>> GetListCityByUf(string uf);
        //Task<IEnumerable<StateDTO>> GetListState();
        //Task<IEnumerable<PatrimonyTypeDTO>> GetAllPatrimonyType();
        //Task<IEnumerable<DebtOptionDTO>> GetAllDebtOption();
        //Task<IEnumerable<IncomeOptionDTO>> GetAllIncomeOption();
        //Task<IEnumerable<IncomeTypeDTO>> GetAllIncomeType();
        //Task<IEnumerable<SourceIncomeTypeDTO>> GetAllSourceIncomeType();
        //Task<IEnumerable<PropertyTypeDTO>> GetAllPropertyType();
        //Task<int> GetCodFichaByCpf(string cpf, string flag);
        ////# GetAllFichaStatus
        //Task<IEnumerable<FichaStatusDTO>> GetAllFichaStatus();
        //Task<IEnumerable<MotorCredDTO>> GetMotorCredResult(int ficha);

        //Task<IEnumerable<ProductGridDTO>> GetHolderResult(DateTime from, DateTime to);
        //Task<IEnumerable<MotorCredDTO>> GetMotorCredResult(DateTime from, DateTime to);
        //Task<IEnumerable<Smartfill>> GetSmartfill(Guid holderId);
    }
}