using Symulator.Domain.Message;

namespace Symulator.Domain.Frame
{
    public interface IFrameInterceptor<T>
    {
        void Apply(T response, bool isCorrect);

        void Subscribe(IMessageService messageService);
    }
}
