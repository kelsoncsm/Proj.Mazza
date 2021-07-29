using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Proj.Mazza.Application.Contracts;
using Proj.Mazza.Application.DTOs;

using Proj.Mazza.Domain.Aggregations.Products;

using Proj.Mazza.Domain.Common.Helpers;


using AutoMapper.Configuration;
using Proj.Mazza.Domain.Aggregations.Products.Repositories;
using AutoMapper;
using Proj.Mazza.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Proj.Mazza.Application.QueryHandlers
{
    public class ProductQueryHandler : IProductQueryHandler
    {
       
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductQueryHandler( IProductRepository productRepository, IMapper mapper)
        {
           
            _productRepository = productRepository;
            _mapper = mapper;


        }


        public async Task<IEnumerable<ProductGridDTO>> GetAllProduct()
        {

            var product = await _productRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductGridDTO>>(product);
        }

        /// <summary>
        /// Busca o produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductDTO> GetProductById(Guid id)
        {

            var product = await _productRepository.FindAsync(h => h.Id == id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductGridDTO>> GetSearch(SearchModel objetoPesquisa)
        {

            var product = await _productRepository.GetAll();


            if (!string.IsNullOrEmpty(objetoPesquisa.Name))
            {
                product = product.Where(x => EF.Functions.Like(x.Name, "%" + objetoPesquisa.Name + "%"));
            }


            if (objetoPesquisa.CategoryId.HasValue)
            {
                product = product.Where(x => x.Category.Equals(objetoPesquisa.CategoryId.Value));
            }

            return _mapper.Map<IEnumerable<ProductGridDTO>>(product);

        }


        ///// <summary>
        ///// Lista os proprietários participantes pelo id do proprietário principal
        ///// </summary>
        ///// <param name="principalId">Id do propriet�rio principal</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ProductDTO>> GetProductsByPrincipal(Guid principalId)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    using var multi = await conn.QueryMultipleAsync(
        //        sql: "holder.[PROC_FETCH_Products_BY_PRINCIPAL]",
        //        param: new { Id = principalId },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    var Products = multi.Read<ProductDTO>().ToList();
        //    var addresses = multi.Read<AddressDTO>().ToList();

        //    if (!(Products is null))
        //        Products.ForEach(h => h.Address = addresses.FirstOrDefault(addresses => addresses.HolderId == h.Id));

        //    return Products;
        //}

        ///// <summary>
        ///// Lista os arquivos
        ///// </summary>
        ///// <param name="holderId">Id do titular</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ArchiveDTO>> GetArchiveByHolder(Guid holderId, int? exceptStatus = null)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryAsync<ArchiveDTO>(
        //        sql: "holder.[PROC_FETCH_ARCHIVES_BY_HOLDER]",
        //        param: new
        //        {
        //            HolderId = holderId,
        //            ExceptStatus = exceptStatus
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}

        ///// <summary>
        ///// Lista os débitos
        ///// </summary>
        ///// <param name="holderId">Id do titular</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<DebtDTO>> GetAllDebtsByHolder(Guid holderId)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryAsync<DebtDTO>(
        //     sql: "holder.[PROC_FETCH_DEBTS_BY_HOLDER]",
        //     param: new { HolderId = holderId },
        //     commandType: System.Data.CommandType.StoredProcedure);

        //    //var debt = await conn.QueryAsync<DebtDTO, DebtOptionDTO, DebtDTO>(
        //    //    sql: "holder.[PROC_FETCH_DEBTS_BY_HOLDER]",
        //    //    (debt, debtOption) =>
        //    //    {
        //    //        debt.DebtOption = debtOption;
        //    //        return debt;
        //    //    }, splitOn: "DebtOptionId",
        //    //    param: new { HolderId = holderId },
        //    //    commandType: System.Data.CommandType.StoredProcedure);


        //    //return debt;
        //}

        ///// <summary>
        ///// Lista 
        ///// </summary>
        ///// <param name="holderId">Id do titular</param>
        ///// <returns></returns>
        ///// <summary>
        ///// Lista 
        ///// </summary>
        ///// <param name="holderId">Id do titular</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<PatrimonyDTO>> GetAllPatrimoniesByHolder(Guid holderId)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryAsync<PatrimonyDTO>(
        //        sql: "holder.[PROC_FETCH_PATRIMONIES_BY_HOLDER]",
        //        param: new { HolderId = holderId },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}

        ///// <summary>
        ///// Lista as receitas
        ///// </summary>
        ///// <param name="holderId">Id do titular</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<IncomeDTO>> GetAllIncomesByHolder(Guid holderId)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    //return await conn.QueryAsync<IncomeDTO, IncomeOptionDTO, IncomeDTO>(
        //    //    sql: "holder.[PROC_FETCH_INCOMES_BY_HOLDER]",
        //    //    (income, incomeOption) =>
        //    //    {
        //    //        income.IncomeOption = incomeOption;
        //    //        return income;
        //    //    }, splitOn: "IncomeOptionId",
        //    //    param: new { HolderId = holderId },
        //    //    commandType: System.Data.CommandType.StoredProcedure);


        //    return await conn.QueryAsync<IncomeDTO>(
        //        sql: "holder.[PROC_FETCH_INCOMES_BY_HOLDER]",
        //        param: new { HolderId = holderId },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}

        ///// <summary>
        ///// Lista as profissões
        ///// </summary>
        ///// <param name="holderId">Id do titular</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ProfessionDTO>> GetAllProfessionsByHolder(Guid holderId)
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<ProfessionDTO>(
        //      sql: "holder.PROC_FETCH_PROFESSIONS_BY_HOLDER",
        //      param: new { HolderId = holderId },
        //      commandType: System.Data.CommandType.StoredProcedure);


        //    }

        //} //

        //public async Task<ProfessionDTO> GetProfessionByHolder(Guid holderId)
        //{



        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    using var multi = await conn.QueryMultipleAsync(
        //          sql: "holder.PROC_FETCH_PROFESSION_BY_HOLDER",
        //          param: new { HolderId = holderId },
        //          commandType: System.Data.CommandType.StoredProcedure);

        //    var profession = multi.ReadSingleOrDefault<ProfessionDTO>();
        //    var address = multi.ReadSingleOrDefault<AddressDTO>();

        //    if (profession != null)
        //    {
        //        profession.Address = address;
        //    }
        //    else
        //    {
        //        profession = new ProfessionDTO();
        //        profession.Address = new AddressDTO();
        //    }
        //    return profession;

        //}

        //public async Task<IEnumerable<ProfessionDTO>> GetOutherSourcesIncomeByHolder(Guid holderId)
        //{

        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<ProfessionDTO>(
        //      sql: "holder.PROC_FETCH_ANOTHER_INCOMES_BY_HOLDER",
        //      param: new { HolderId = holderId },
        //      commandType: System.Data.CommandType.StoredProcedure);


        //    }


        //}

        //public async Task<ProfessionDTO> GetProfessionById(int id)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryFirstOrDefaultAsync<ProfessionDTO>(
        //        sql: "[holder].[PROC_FETCH_PROFESSION_BY_ID]",
        //        param: new { Id = id },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}

        ///// <summary>
        ///// Lista os documentos requiridos para o cadastro
        ///// </summary>
        ///// <param name="holderId"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<DocumentDTO>> GetAllDocumentsByHolder(Guid holderId)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    var documents = await conn.QueryAsync<DocumentDTO>(
        //        sql: "holder.PROC_FETCH_DOCUMENTS",
        //        param: new { HolderId = holderId },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    foreach (var document in documents)
        //    {
        //        if (String.IsNullOrWhiteSpace(document.SubTitle))
        //            document.SubTitle = DocumentSubtitle.GetSubtitle((EArchiveType)document.ArchiveType);

        //        if (String.IsNullOrWhiteSpace(document.Description))
        //            document.Description = DocumentDescription.GetDescription((EArchiveType)document.ArchiveType);
        //    }

        //    return documents;
        //}

        ///// <summary>
        ///// Verifica se CPF já está registrado
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <returns></returns>
        //public async Task<bool> CheckCPFAlreadyRegistered(string cpf, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryFirstOrDefaultAsync<bool>(sql: "SELECT IIF(COUNT(CPF) > 0, 1, 0) FROM holder.Products WHERE  Flag = @Flag AND  CPF LIKE @CPF", new { CPF = $"%{cpf}%", Flag = flag });
        //}

        //public async Task<bool> CheckCelPhoneAlreadyRegistered(string celPhone, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryFirstOrDefaultAsync<bool>(sql: "SELECT IIF(COUNT(CelPhone) > 0, 1, 0) FROM holder.Products WHERE Flag = @Flag AND  CelPhone LIKE @CelPhone", new { CelPhone = $"%{celPhone}%", Flag = flag });
        //}

        ///// <summary>
        ///// Verifica se e-mail já está registrado
        ///// </summary>
        ///// <param name="email"></param>
        ///// <returns></returns>
        //public async Task<bool> CheckEmailAlreadyRegistered(string email, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryFirstOrDefaultAsync<bool>(sql: "SELECT IIF(COUNT(EMail) > 0, 1, 0) FROM holder.Products WHERE Flag = @Flag AND  EMail LIKE @EMail", new { EMail = $"%{email}%", Flag = flag });
        //}

        ///// <summary>
        ///// Temporário
        ///// </summary>
        ///// <param name="principalId"></param>
        ///// <returns></returns>
        //public async Task<ProductDTO> GetHolderByCPF(string cpf, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    return await conn.QueryFirstOrDefaultAsync<ProductDTO>(
        //        sql: $"SELECT * FROM holder.Products h WHERE h.CPF = @cpf AND h.flag = @flag",
        //        param: new { cpf = cpf, flag = flag });
        //}

        ///// <summary>
        ///// Lista os Products pelo campo busca
        ///// </summary>
        ///// <param name="campoBusca"></param>
        ///// <param name="accountId"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ProductGridDTO>> GetAllHolder(GridSearch parameters)
        //{
        //    Guid? defaultId = null;
        //    bool isSalesman = parameters.Role == "Vendedor";
        //    bool isAdvisory = parameters.Role == "Assessoria";
        //    bool isAgent = parameters.Role == "Agente";

        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();


        //    var Products = await conn.QueryAsync<ProductGridDTO>(
        //        sql: "agent.[PROC_FETCH_ALL_Products_PRINCIPAL]",
        //        param: new
        //        {
        //            Cpf = parameters.CampoBusca,
        //            AccountId = isSalesman || isAdvisory ? parameters.AccountId : defaultId,
        //            Tipo = parameters.Tipo,
        //            RegisterStatus = parameters.RegisterStatus,
        //            Flag = parameters.Flag
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    if (Products is null)
        //        return Products;

        //    //Incluindo Assesoria se existir
        //    foreach (var holder in Products)
        //    {
        //        var sameHolder = Products.ToList().FindAll(x => x.Id == holder.Id && (x.Advisory != holder.Advisory || x.SalesMan != holder.SalesMan))?.LastOrDefault();

        //        if (sameHolder is not null)
        //        {
        //            holder.Advisory = String.IsNullOrWhiteSpace(holder.Advisory) ? sameHolder.Advisory : holder.Advisory;
        //            holder.SalesMan = String.IsNullOrWhiteSpace(holder.SalesMan) ? sameHolder.SalesMan : holder.SalesMan;

        //            sameHolder.Advisory = holder.Advisory;
        //            sameHolder.SalesMan = holder.SalesMan;
        //        }
        //    }

        //    #region Permissions

        //    IEnumerable<PermissionDTO> permissions = new List<PermissionDTO>();
        //    GroupRecursionDTO recursion = new();

        //    //Verificar permissões
        //    if (parameters.AccountId is not null)
        //    {
        //        permissions = await _permissionQueryHandler.GetPermissionsByUserId(parameters.AccountId ?? new Guid());
        //        recursion = await _groupQueryHandler.GetRecursionByUserId(parameters.AccountId ?? new Guid()) ?? new GroupRecursionDTO();
        //    }

        //    recursion.Salesmen = recursion.Salesmen is null ? new List<SalesmanDTO>() : recursion.Salesmen;
        //    recursion.PointsSale = recursion.PointsSale is null ? new List<PointSaleDTO>() : recursion.PointsSale;

        //    //Verificações de acessos
        //    bool hasAccessMobile = permissions.Any(p => p.PermissionModule == EPermissionModule.HOME_SCREEN_MOBILE
        //            && (p.PermissionType is (int)EHomeScreenMobile.VIEW_MOBILE_SIMPLE or (int)EHomeScreenMobile.VIEW_MOBILE_SIMPLE_ACCESS_RECORD));

        //    bool hasAccessDesktop = permissions.Any(p => p.PermissionModule == EPermissionModule.HOME_SCREEN_WEB_DESKTOP
        //        && (p.PermissionType is (int)EHomeScreenWebDesktop.VIEW_WEB_ALL or (int)EHomeScreenWebDesktop.VIEW_WEB_RESTRICT));

        //    bool hasAccessWebRestrict = permissions.Any(p => p.PermissionModule == EPermissionModule.HOME_SCREEN_WEB_DESKTOP
        //        && p.PermissionType == (int)EHomeScreenWebDesktop.VIEW_WEB_RESTRICT);

        //    bool hasAccessWebAll = permissions.Any(p => p.PermissionModule == EPermissionModule.HOME_SCREEN_WEB_DESKTOP
        //        && p.PermissionType == (int)EHomeScreenWebDesktop.VIEW_WEB_ALL);

        //    bool hasAccessVivaz = permissions.Any(p => p.PermissionModule == EPermissionModule.FLAG && p.PermissionType == (int)EFlag.VIVAZ);
        //    bool hasAccessLiving = permissions.Any(p => p.PermissionModule == EPermissionModule.FLAG && p.PermissionType == (int)EFlag.LIVING);
        //    bool hasAccessCyrela = permissions.Any(p => p.PermissionModule == EPermissionModule.FLAG && p.PermissionType == (int)EFlag.CYRELA);


        //    //Retorna vazio se o usuario não tem acesso ao Web Desktop nem ao Mobile
        //    if (!hasAccessDesktop && !hasAccessMobile)
        //    {
        //        return new List<ProductGridDTO>();
        //    }

        //    //Retorna vazio se o usuario não tem acesso ao Web Mobile (apenas para vendedores)
        //    if (!hasAccessMobile && isSalesman)
        //    {
        //        return new List<ProductGridDTO>();
        //    }

        //    if (isSalesman)
        //    {
        //        return Products.DistinctBy(x => x.Id);
        //    }

        //    List<string> noAccess = new();

        //    //Se não for Assessoria
        //    if (!isAdvisory)
        //    {
        //        //Removendo fichas por bandeiras
        //        if (!hasAccessVivaz)
        //        {
        //            var found = Products.Where(x => x.Description == "Vivaz");
        //            foreach (var item in found)
        //                noAccess.Add(item.Cod);
        //        }

        //        if (!hasAccessLiving)
        //        {
        //            var found = Products.Where(x => x.Description == "Living");
        //            foreach (var item in found)
        //                noAccess.Add(item.Cod);
        //        }

        //        if (!hasAccessCyrela)
        //        {
        //            var found = Products.Where(x => x.Description == "Cyrela");
        //            foreach (var item in found)
        //                noAccess.Add(item.Cod);
        //        }

        //        //Removendo fichas por vendedores e pontos de venda
        //        foreach (var holder in Products.DistinctBy(x => x.Id))
        //        {
        //            bool hasSalesmenGroupAccess = recursion.Salesmen.Any(p => p.AccountId == holder.SalesmanAccountId);
        //            bool hasSalesman = holder.SalesmanAccountId != null;

        //            bool hasPointsSaleGroupAccess = recursion.PointsSale.Any(p => p.PointSaleCRMId == holder.PointSaleId);
        //            bool hasPointSale = holder.PointSaleId != null;


        //            //A ficha está ligada a um vendedor, porém o usuario não tem acesso a este vendedor
        //            if(hasSalesman && !hasSalesmenGroupAccess)
        //            {
        //                noAccess.Add(holder.Cod);
        //            }

        //            //A ficha está ligada a um ponto de venda, porém o usuario não tem acesso a este ponto de venda
        //            if (hasPointSale && !hasPointsSaleGroupAccess)
        //            {
        //                noAccess.Add(holder.Cod);
        //            }

        //            //A ficha não está ligada a um vendedor ou ponto de venda
        //            if(!hasSalesman || !hasPointSale)
        //            {
        //                if (!isAgent)
        //                {
        //                    noAccess.Add(holder.Cod);
        //                }
        //            }
        //        }

        //        //Removendo por localização
        //        foreach (var holder in Products)
        //        {
        //            var location = permissions.Where(p => p.PermissionModule == EPermissionModule.SP ||
        //                                                  p.PermissionModule == EPermissionModule.RJ ||
        //                                                  p.PermissionModule == EPermissionModule.SUL ||
        //                                                  p.PermissionModule == EPermissionModule.CORPORATIVO);

        //            if (!location.Any(p => p.PermissionType == holder.LocalInterestId))
        //                noAccess.Add(holder.Cod);
        //        }
        //    }

        //    //Removendo visualização de dados restritos
        //    if (hasAccessWebRestrict || !hasAccessWebAll)
        //    {
        //        foreach (var holder in Products)
        //        {
        //            holder.Cpf = !isSalesman ? string.Empty : holder.Cpf;
        //            holder.Email = string.Empty;
        //            holder.CelPhone = string.Empty;
        //            holder.PvName = string.Empty;
        //            holder.Advisory = string.Empty;
        //            holder.SalesMan = !isSalesman ? string.Empty : holder.SalesMan;
        //        }
        //    }
        //    #endregion

        //    foreach (var holder in Products)
        //    {
        //        holder.EndDate = !(holder.RegisterStatus is ERegisterStatus.APPROVED or ERegisterStatus.APPROVED_MEDIANTE or ERegisterStatus.REPROVED or ERegisterStatus.REMOVED_BY_AGENT or ERegisterStatus.REMOVED_BY_CLIENT)
        //             ? holder.EndDate
        //             : null;
        //    }

        //    return Products.DistinctBy(x => x.Id).Where(h => !noAccess.Contains(h.Cod));
        //}

        ///// <summary>
        ///// Temporário
        ///// </summary>
        ///// <param name="principalId"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ProductDTO>> GetProductsByID(Guid id)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    var queryResult = await conn.QueryMultipleAsync(
        //        sql: "agent.[PROC_FETCH_ALL_Products_BY_ID]",
        //        param: new { Id = id },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    var holderDTO = queryResult.Read<ProductDTO>()?.ToList();

        //    try
        //    {
        //        var userDTO = queryResult.Read<UserADDTO>()?.ToList();
        //        if (userDTO is not null && holderDTO is not null)
        //        {
        //            foreach (var holder in holderDTO)
        //            {
        //                holder.Salesman = userDTO.FirstOrDefault(u => u.Role != "Assessoria");
        //            }
        //        }
        //    }
        //    catch { }

        //    return holderDTO;
        //}

        ///// <summary>
        ///// Lista o holder pelo CPF
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ProductCadastroDTO>> GetHolderRegister(string cpf, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    using var multi = await conn.QueryMultipleAsync(
        //        sql: "agent.[PROC_FETCH_HOLDER_BY_CPF]",
        //        param: new { cpf = cpf, flag = flag },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    var Products = multi.Read<ProductCadastroDTO>().ToList();
        //    var addresses = multi.Read<AddressDTO>().ToList();

        //    if (!(Products is null))
        //        Products.ForEach(h => h.Address = addresses.FirstOrDefault(addresses => addresses.HolderId == h.Id));

        //    return Products;
        //}

        ///// <summary>
        ///// Lista os documentos pelo CPF do holder
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<DocumentGridDTO>> GetAllDocumentsByCPF(string cpf, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    using var queryResult = await conn.QueryMultipleAsync(
        //        sql: "agent.[PROC_FETCH_DOCUMENTS_BY_CPF]",
        //        param: new { Cpf = cpf, Flag = flag },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    var documents = queryResult.Read<DocumentGridDTO>().ToList();
        //    var archives = queryResult.Read<ArchiveDTO>().ToList();

        //    string description = "";

        //    List<DocumentGridDTO> list = new();

        //    foreach (var doc in documents)
        //    {
        //        if (!description.Contains(doc.ContainerTypeDesc))
        //        {
        //            DocumentGridDTO entidade = new DocumentGridDTO
        //            {
        //                ContainerType = doc.ContainerType,
        //                ContainerTypeDesc = doc.ContainerTypeDesc,
        //                IsRequired = doc.IsRequired,
        //                RegistrationStatusDesc = doc.RegistrationStatusDesc,
        //                RegistrationStatus = doc.RegistrationStatus,
        //                listaDocumentos = new List<DocumentGridDTO>()
        //            };

        //            entidade.listaDocumentos = (from l in documents where l.ContainerTypeDesc == doc.ContainerTypeDesc select l).ToList();
        //            description = entidade.ContainerTypeDesc;

        //            list.Add(entidade);
        //        }
        //    }

        //    foreach (var item in list)
        //    {
        //        foreach (var doc in item.listaDocumentos)
        //        {
        //            try
        //            {
        //                var archive = archives.FindAll(a => a.ArchiveType == doc.ArchiveType && a.ContainerType == doc.ContainerType)?.OrderByDescending(x => x.UpdatedAt).FirstOrDefault();
        //                doc.CreatedAt = null;

        //                if (archive is not null)
        //                {
        //                    if (doc.RegistrationStatus is not (int)ERegistrationStatus.PENDING)
        //                    {
        //                        doc.CreatedAt = archive.CreatedAt;
        //                        doc.ConclusionAt = (archive.RegistrationStatus is ERegistrationStatus.APPROVED or ERegistrationStatus.REJECTED or ERegistrationStatus.NOT_NECESSARY) ? (archive.UpdatedAt ?? archive.CreatedAt) : null;
        //                    }
        //                }
        //            }
        //            catch { }
        //        }
        //    }

        //    return list;
        //}

        ///// <summary>
        ///// Lista todos arquivos pelo CPF, tipo de arquivo e status
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <param name="type"></param>
        ///// <param name="registrationStatus"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ArchiveGridDTO>> GetAllArquivesByCpfAndType(string cpf, int type, int registrationStatus, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    return await conn.QueryAsync<ArchiveGridDTO>(
        //        sql: "agent.[PROC_FETCH_ALL_ARCHIVES_BY_CPF_AND_TYPE]",
        //        param: new
        //        {
        //            Cpf = cpf,
        //            ArchiveType = type,
        //            RegistrationStatus = registrationStatus,
        //            Flag = flag
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}

        ///// <summary>
        ///// Lista arquivos pelo tipo, status e cpf do holder
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <param name="type"></param>
        ///// <param name="registrationStatus"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<ArchiveGridDTO>> GetArquivesByCpfAndType(string cpf, int type, int registrationStatus, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    if (registrationStatus == (int)ERegistrationStatus.PENDING)
        //    {
        //        registrationStatus = (int)ERegistrationStatus.DELETED;
        //    }

        //    IEnumerable<ArchiveGridDTO> archives = await conn.QueryAsync<ArchiveGridDTO>(
        //        sql: "agent.[PROC_FETCH_ARCHIVES_BY_CPF_AND_TYPE]",
        //        param: new
        //        {
        //            Cpf = cpf,
        //            ArchiveType = type,
        //            RegistrationStatus = registrationStatus,
        //            StatusDeleted = ERegistrationStatus.DELETED,
        //            Flag = flag
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    foreach (var archive in archives)
        //    {
        //        archive.ConclusionAt = !(archive.RegistrationStatus is (int)ERegistrationStatus.PENDING or (int)ERegistrationStatus.IN_ANALYSIS or (int)ERegistrationStatus.AWAITING)
        //             ? archive.UpdatedAt
        //             : null;
        //    }

        //    return archives.OrderByDescending(x => x.CreatedAt).ToList();
        //}

        //public async Task<IEnumerable<StateDTO>> GetListState()
        //{

        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    IEnumerable<StateDTO> _lista = await conn.QueryAsync<StateDTO>(
        //        sql: "integration.[PROC_GET_STATE]",
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    return _lista;

        //}

        //public async Task<CityDTO> GetCityById(int id)
        //{
        //    if (id == 0) return null;

        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    var city = await conn.QueryFirstOrDefaultAsync<CityDTO>(sql: "integration.[PROC_GET_CITY_BY_ID]",
        //                     param: new { id },
        //                     commandType: System.Data.CommandType.StoredProcedure);

        //    return city;
        //}


        //public async Task<IEnumerable<CityDTO>> GetListCityByUf(string uf)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    IEnumerable<CityDTO> _lista = await conn.QueryAsync<CityDTO>(
        //        sql: "integration.[PROC_GET_CITY_BY_STATE]",
        //          param: new { uf = uf },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    return _lista;
        //}

        //public async Task<IEnumerable<PatrimonyTypeDTO>> GetAllPatrimonyType()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<PatrimonyTypeDTO>(
        //            sql: "SELECT Id, Description FROM holder.PatrimonyType WITH(NOLOCK) ORDER BY Id ASC", System.Data.CommandType.Text);
        //    }
        //}

        //public async Task<IEnumerable<DebtOptionDTO>> GetAllDebtOption()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<DebtOptionDTO>(
        //            sql: "SELECT Id, Description FROM holder.DebtOption WITH(NOLOCK) ORDER BY Id ASC", System.Data.CommandType.Text);
        //    }
        //}

        //public async Task<IEnumerable<IncomeOptionDTO>> GetAllIncomeOption()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<IncomeOptionDTO>(
        //            sql: "SELECT Id, Description FROM holder.IncomeOption WITH(NOLOCK) ORDER BY Id ASC", System.Data.CommandType.Text);
        //    }
        //}

        //public async Task<IEnumerable<IncomeTypeDTO>> GetAllIncomeType()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<IncomeTypeDTO>(
        //            sql: "SELECT Id, Description FROM holder.IncomeType WITH(NOLOCK) ORDER BY Id ASC", System.Data.CommandType.Text);
        //    }
        //}

        //public async Task<IEnumerable<SourceIncomeTypeDTO>> GetAllSourceIncomeType()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<SourceIncomeTypeDTO>(
        //            sql: "SELECT Id, Description, Extra AS IncomeCharacteristic FROM holder.SourceIncomeType WITH(NOLOCK) ORDER BY Id ASC", System.Data.CommandType.Text);
        //    }
        //}

        //public async Task<IEnumerable<PropertyTypeDTO>> GetAllPropertyType()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<PropertyTypeDTO>(
        //            sql: "SELECT Id, Description FROM holder.PropertyType WITH(NOLOCK) ORDER BY Id ASC", System.Data.CommandType.Text);
        //    }
        //}

        ///// <summary>
        ///// Consulta número da Ficha pelo CPF do Holder
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <returns></returns>
        //public async Task<int> GetCodFichaByCpf(string cpf, string flag)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    var holder = await conn.QueryFirstOrDefaultAsync<ProductDTO>(
        //        sql: "holder.[PROC_FECTH_COD_FICHA_BY_CPF]",
        //        param: new { Cpf = cpf, Flag = flag },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    return holder is null ? 0 : holder.TokenNumber;
        //}
        ///// <summary>
        ///// Consulta número da Ficha pelo CPF do Holder
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <returns></returns>
        //public async Task<int> GetCodFichaById(Guid id)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));

        //    await conn.OpenAsync();

        //    var holder = await conn.QueryFirstOrDefaultAsync<ProductDTO>(
        //        sql: "holder.[PROC_FECTH_COD_FICHA_BY_ID]",
        //        param: new { Id = id },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    return holder is null ? 0 : holder.TokenNumber;
        //}
        //public async Task<IEnumerable<FichaStatusDTO>> GetAllFichaStatus()
        //{
        //    using (var conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        //    {
        //        await conn.OpenAsync();

        //        return await conn.QueryAsync<FichaStatusDTO>(
        //            sql: "SELECT [RegisterStatus], [Description] FROM dbo.FichaStatus WITH(NOLOCK) ORDER BY [Priority] ASC", System.Data.CommandType.Text);
        //    }
        //}
        ///// <summary>
        ///// Retorna o resultado do motor de crédito pelo numero da ficha
        ///// </summary>
        ///// <param name="ficha"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<MotorCredDTO>> GetMotorCredResult(int ficha)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    return await conn.QueryAsync<MotorCredDTO>(
        //        sql: "holder.[PROC_FETCH_MOTOR_CRED_RESULT]",
        //        param: new { Ficha = ficha },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}
        //public async Task<IEnumerable<MotorCredDTO>> GetMotorCredResult(DateTime from, DateTime to)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    return await conn.QueryAsync<MotorCredDTO>(
        //        sql: "holder.[PROC_FETCH_MOTOR_CRED_RESULT_BY_DATE]",
        //        param: new
        //        {
        //            DateFrom = from,
        //            DateTo = to
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //}

        //public async Task<IEnumerable<ProductGridDTO>> GetHolderResult(DateTime from, DateTime to)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();


        //    IEnumerable<ProductGridDTO> result = await conn.QueryAsync<ProductGridDTO>(
        //       sql: "holder.[PROC_FETCH_HOLDER_RESULT_BY_DATE]",
        //        param: new
        //        {
        //            DateFrom = from,
        //            DateTo = to
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    foreach (var resultado in result)
        //    {
        //        resultado.EndDate = !(resultado.RegisterStatus is ERegisterStatus.APPROVED or ERegisterStatus.APPROVED_MEDIANTE or ERegisterStatus.REPROVED or ERegisterStatus.REMOVED_BY_AGENT or ERegisterStatus.REMOVED_BY_CLIENT)
        //             ? resultado.EndDate
        //             : null;
        //    }


        //    return result;

        //}



        ///// <summary>
        ///// TO DO
        ///// </summary>
        ///// <param name="holderId"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<Smartfill>> GetSmartfill(Guid holderId)
        //{
        //    using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    await conn.OpenAsync();

        //    #region FETCH
        //    //Ph3a
        //    var ph3aResult = await conn.QueryFirstOrDefaultAsync<Smartfill>(
        //        sql: "[integration].[PROC_FETCH_PH3A_SMARTFILL]",
        //        param: new { HolderId = holderId },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    //Archives and Holder FirstName
        //    using var multi = await conn.QueryMultipleAsync(
        //        sql: "[holder].[PROC_FETCH_ARCHIVES_SMARTFILL]",
        //        param: new { HolderId = holderId },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    var archives = multi.Read<ArchiveDTO>().ToList();
        //    var holder = multi.Read<ProductDTO>().FirstOrDefault();
        //    #endregion

        //    #region Extract Data
        //    //Smartfill
        //    var smartfill = new List<Smartfill>();

        //    string holderFirstName = "";
        //    string motherFirstName = "";

        //    if (ph3aResult is not null)
        //    {
        //        holderFirstName = ph3aResult.FullName?.Split(' ')?.FirstOrDefault()?.Trim();
        //        motherFirstName = ph3aResult.MotherName?.Split(' ')?.FirstOrDefault()?.Trim();
        //        ph3aResult.Source = ESourceSmartfill.PH3A;

        //        smartfill.Add(ph3aResult);
        //    }

        //    if (holder is not null)
        //    {
        //        holderFirstName = string.IsNullOrWhiteSpace(holderFirstName)
        //                        ? holder.FirstName?.Split(' ')?.FirstOrDefault()?.Trim()
        //                        : holderFirstName;
        //    }

        //    if (archives is not null)
        //    {
        //        var archivesRG_CNH = archives.FindAll(a =>
        //            a.ContainerType == (int)EContainerType.IDENTIFICATION && a.ArchiveType == (int)EArchiveType.RG_CNH)
        //            ?? new List<ArchiveDTO>();

        //        var archivesBirthCertificate = archives.FindAll(a =>
        //            a.ContainerType == (int)EContainerType.IDENTIFICATION && a.ArchiveType == (int)EArchiveType.BIRTH_CERTIFICATE)
        //            ?? new List<ArchiveDTO>();

        //        string ocrRgCnh = "";
        //        string ocrBirthCertificate = "";

        //        archivesRG_CNH.ForEach(a => ocrRgCnh += $"\n{a.Ocr}");
        //        archivesBirthCertificate.ForEach(a => ocrBirthCertificate += $"\n{a.Ocr}");

        //        Document rgCnh = ExtractData.Process(ocrRgCnh?.Replace("\n", " "), holderFirstName, motherFirstName, out EDocumentModel modelRgCnh);
        //        Document birthCertificate = ExtractData.Process(ocrBirthCertificate?.Replace("\n", " "), holderFirstName, motherFirstName, out EDocumentModel modelBirthCertificate);

        //        ESourceSmartfill source1 = modelRgCnh switch
        //        {
        //            EDocumentModel.RG_01 => ESourceSmartfill.RG,
        //            EDocumentModel.RG_02 => ESourceSmartfill.RG,
        //            EDocumentModel.RG_03 => ESourceSmartfill.RG,
        //            EDocumentModel.CNH_01 => ESourceSmartfill.CNH,
        //            _ => ESourceSmartfill.OTHER
        //        };

        //        ESourceSmartfill source2 = modelBirthCertificate switch
        //        {
        //            EDocumentModel.BIRTH_CERTIFICATE_01 => ESourceSmartfill.BIRTH_CERTIFICATE,
        //            _ => ESourceSmartfill.OTHER
        //        };

        //        if (rgCnh is not null && source1 != ESourceSmartfill.OTHER)
        //        {
        //            smartfill.Add(new Smartfill()
        //            {
        //                FullName = rgCnh.FullName,
        //                FatherName = string.IsNullOrWhiteSpace(rgCnh.FatherName) ? (rgCnh.Parents == rgCnh.MotherName ? null : rgCnh.Parents) : rgCnh.FatherName,
        //                MotherName = string.IsNullOrWhiteSpace(rgCnh.MotherName) ? rgCnh.Parents : rgCnh.MotherName,
        //                Organ = string.IsNullOrWhiteSpace(rgCnh.Organ) ? rgCnh.DocumentSource : rgCnh.Organ,
        //                IssueDate = rgCnh.IssueDate,
        //                Source = source1
        //            });
        //        }

        //        if (birthCertificate is not null && source2 != ESourceSmartfill.OTHER)
        //        {
        //            smartfill.Add(new Smartfill()
        //            {
        //                FullName = birthCertificate.FullName,
        //                FatherName = string.IsNullOrWhiteSpace(birthCertificate.FatherName) ? birthCertificate.Parents : birthCertificate.FatherName,
        //                MotherName = string.IsNullOrWhiteSpace(birthCertificate.MotherName) ? birthCertificate.Parents : birthCertificate.MotherName,
        //                Source = source2
        //            });
        //        }
        //    }
        //    #endregion

        //    return smartfill;
        //}
    }
}