using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Infrastructure.Translator
{
    public interface ITranslator
    {
        string Translate(ResourceKey key);
    }
}
