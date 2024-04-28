using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DynamicData;
using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia.Browser;

public class EncoderDecoder
{
  private readonly JsonSerializerOptions _options;

  public EncoderDecoder(params Type[] messageTypes)
  {
    _options = new()
    {
      TypeInfoResolver = new TypeResolver(messageTypes),
    };
  }

  public string ToJson(IMessage msg) => JsonSerializer.Serialize(msg, _options);

  public IMessage FromJson(string json) => JsonSerializer.Deserialize<IMessage>(json, _options)!;

  class TypeResolver : DefaultJsonTypeInfoResolver
  {
    private readonly JsonPolymorphismOptions _polymorphism;

    public TypeResolver(IEnumerable<Type> messageTypes)
    {
      _polymorphism = new JsonPolymorphismOptions
      {
        IgnoreUnrecognizedTypeDiscriminators = true,
        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
      };
      _polymorphism.DerivedTypes.AddRange(messageTypes.Select(mt => new JsonDerivedType(mt, mt.Name)));
    }

    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
      var jsonTypeInfo = base.GetTypeInfo(type, options);
      if (type == typeof(IMessage))
        jsonTypeInfo.PolymorphismOptions = _polymorphism;
      return jsonTypeInfo;
    }
  }
}