namespace OrderManagement.Assembler
{
    public interface IAssembler<TDto, TDomainObject>
    {
        TDto ToDto(TDomainObject domainObject);

        TDomainObject ToDomainObject(TDto dto);
    }
}