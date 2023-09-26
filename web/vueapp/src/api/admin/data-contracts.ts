/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

/**
 * Unspecified=0,Unix=1,InterNetwork=2,ImpLink=3,Pup=4,Chaos=5,Ipx=6,Ipx=6,Iso=7,Iso=7,Ecma=8,DataKit=9,Ccitt=10,Sna=11,DecNet=12,DataLink=13,Lat=14,HyperChannel=15,AppleTalk=16,NetBios=17,VoiceView=18,FireFox=19,Banyan=21,Atm=22,InterNetworkV6=23,Cluster=24,Ieee12844=25,Irda=26,NetworkDesigners=28,Max=29,Packet=65536,ControllerAreaNetwork=65537,Unknown=-1
 * @format int32
 */
export type AddressFamily =
  | 0
  | 1
  | 2
  | 3
  | 4
  | 5
  | 6
  | 7
  | 8
  | 9
  | 10
  | 11
  | 12
  | 13
  | 14
  | 15
  | 16
  | 17
  | 18
  | 19
  | 21
  | 22
  | 23
  | 24
  | 25
  | 26
  | 28
  | 29
  | 65536
  | 65537
  | -1

/** 添加 */
export interface ApiAddInput {
  /**
   * 所属模块
   * @format int64
   */
  parentId?: number | null
  /** 接口名称 */
  label?: string | null
  /** 接口地址 */
  path?: string | null
  /** 接口提交方法 */
  httpMethods?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

export interface ApiEntity {
  /** @format int64 */
  id?: number
  /** @format int64 */
  createdUserId?: number | null
  /** @maxLength 50 */
  createdUserName?: string | null
  /** @format date-time */
  createdTime?: string | null
  /** @format int64 */
  modifiedUserId?: number | null
  /** @maxLength 50 */
  modifiedUserName?: string | null
  /** @format date-time */
  modifiedTime?: string | null
  isDeleted?: boolean
  /** @format int64 */
  parentId?: number
  name?: string | null
  label?: string | null
  path?: string | null
  httpMethods?: string | null
  description?: string | null
  /** @format int32 */
  sort?: number
  enabled?: boolean
  childs?: ApiEntity[] | null
  permissions?: PermissionEntity[] | null
}

export interface ApiGetOutput {
  /**
   * 所属模块
   * @format int64
   */
  parentId?: number | null
  /** 接口名称 */
  label?: string | null
  /** 接口地址 */
  path?: string | null
  /** 接口提交方法 */
  httpMethods?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 接口Id
   * @format int64
   */
  id: number
}

export interface ApiGetPageDto {
  label?: string | null
}

export interface ApiListOutput {
  /**
   * 接口Id
   * @format int64
   */
  id?: number
  /**
   * 接口父级
   * @format int64
   */
  parentId?: number | null
  /** 接口命名 */
  name?: string | null
  /** 接口名称 */
  label?: string | null
  /** 接口地址 */
  path?: string | null
  /** 接口提交方法 */
  httpMethods?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

/** 接口同步Dto */
export interface ApiSyncDto {
  /** 接口名称 */
  label?: string | null
  /** 接口地址 */
  path?: string | null
  /** 父级路径 */
  parentPath?: string | null
  /** 接口提交方法 */
  httpMethods?: string | null
}

/** 接口同步 */
export interface ApiSyncInput {
  apis?: ApiSyncDto[] | null
}

/** 修改 */
export interface ApiUpdateInput {
  /**
   * 所属模块
   * @format int64
   */
  parentId?: number | null
  /** 接口名称 */
  label?: string | null
  /** 接口地址 */
  path?: string | null
  /** 接口提交方法 */
  httpMethods?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 接口Id
   * @format int64
   */
  id: number
}

export interface AsnEncodedData {
  oid?: Oid
  /** @format byte */
  rawData?: string | null
}

export interface Assembly {
  definedTypes?: TypeInfo[] | null
  exportedTypes?: Type[] | null
  codeBase?: string | null
  entryPoint?: MethodInfo
  fullName?: string | null
  imageRuntimeVersion?: string | null
  isDynamic?: boolean
  location?: string | null
  reflectionOnly?: boolean
  isCollectible?: boolean
  isFullyTrusted?: boolean
  customAttributes?: CustomAttributeData[] | null
  escapedCodeBase?: string | null
  manifestModule?: Module
  modules?: Module[] | null
  /** @deprecated */
  globalAssemblyCache?: boolean
  /** @format int64 */
  hostContext?: number
  /** None=0,Level1=1,Level2=2 */
  securityRuleSet?: SecurityRuleSet
}

export interface AsymmetricAlgorithm {
  /** @format int32 */
  keySize?: number
  legalKeySizes?: KeySizes[] | null
  signatureAlgorithm?: string | null
  keyExchangeAlgorithm?: string | null
}

export interface AuthGetPasswordEncryptKeyOutput {
  /** 缓存键 */
  key?: string | null
  /** 密码加密密钥 */
  encyptKey?: string | null
}

export interface AuthGetUserInfoOutput {
  /** 用户个人信息 */
  user?: AuthUserProfileDto
  /** 用户菜单列表 */
  menus?: AuthUserMenuDto[] | null
  /** 用户权限列表 */
  permissions?: string[] | null
}

export interface AuthGetUserPermissionsOutput {
  /** 用户个人信息 */
  user?: AuthUserProfileDto
  /** 用户权限列表 */
  permissions?: string[] | null
}

/** 登录信息 */
export interface AuthLoginInput {
  /**
   * 账号
   * @minLength 1
   */
  userName: string
  /**
   * 密码
   * @minLength 1
   */
  password: string
  /** 密码键 */
  passwordKey?: string | null
}

export interface AuthUserMenuDto {
  /**
   * 权限Id
   * @format int64
   */
  id?: number
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /** 路由地址 */
  path?: string | null
  /** 路由命名 */
  name?: string | null
  /** 视图地址 */
  viewPath?: string | null
  /** 重定向地址 */
  redirect?: string | null
  /** 权限名称 */
  label?: string | null
  /** 图标 */
  icon?: string | null
  /** 打开 */
  opened?: boolean | null
  /** 隐藏 */
  hidden?: boolean
  /** 打开新窗口 */
  newWindow?: boolean | null
  /** 链接外显 */
  external?: boolean | null
  /** 是否缓存 */
  isKeepAlive?: boolean
  /** 是否固定 */
  isAffix?: boolean
  /** 链接地址 */
  link?: string | null
  /** 是否内嵌窗口 */
  isIframe?: boolean
}

/** 用户个人信息 */
export interface AuthUserProfileDto {
  /** 账号 */
  userName?: string | null
  /** 姓名 */
  name?: string | null
  /** 昵称 */
  nickName?: string | null
  /** 头像 */
  avatar?: string | null
}

/**
 * Standard=1,VarArgs=2,Any=3,HasThis=32,ExplicitThis=64
 * @format int32
 */
export type CallingConventions = 1 | 2 | 3 | 32 | 64

export interface CancellationToken {
  isCancellationRequested?: boolean
  canBeCanceled?: boolean
  waitHandle?: WaitHandle
}

export interface CaptchaData {
  id?: string | null
  backgroundImage?: string | null
  sliderImage?: string | null
}

export interface Claim {
  issuer?: string | null
  originalIssuer?: string | null
  properties?: Record<string, string>
  subject?: ClaimsIdentity
  type?: string | null
  value?: string | null
  valueType?: string | null
}

export interface ClaimsIdentity {
  authenticationType?: string | null
  isAuthenticated?: boolean
  actor?: ClaimsIdentity
  bootstrapContext?: any
  claims?: Claim[] | null
  label?: string | null
  name?: string | null
  nameClaimType?: string | null
  roleClaimType?: string | null
}

export interface ClaimsPrincipal {
  claims?: Claim[] | null
  identities?: ClaimsIdentity[] | null
  identity?: IIdentity
}

/** 添加字典 */
export interface ConfigAddInput {
  /**
   * 配置项名称
   * @minLength 1
   */
  name: string
  /** 配置项编码 */
  code?: string | null
  /** 配置项值 */
  value?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

export interface ConfigGetOutput {
  /**
   * 配置项名称
   * @minLength 1
   */
  name: string
  /** 配置项编码 */
  code?: string | null
  /** 配置项值 */
  value?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

export interface ConfigGetPageDto {
  name?: string | null
}

export interface ConfigGetPageOutput {
  /**
   * 主键Id
   * @format int64
   */
  id?: number
  /** 字典名称 */
  name?: string | null
  /** 字典编码 */
  code?: string | null
  /** 字典值 */
  value?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

/** 修改 */
export interface ConfigUpdateInput {
  /**
   * 配置项名称
   * @minLength 1
   */
  name: string
  /** 配置项编码 */
  code?: string | null
  /** 配置项值 */
  value?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

export interface ConnectionInfo {
  id?: string | null
  remoteIpAddress?: IPAddress
  /** @format int32 */
  remotePort?: number
  localIpAddress?: IPAddress
  /** @format int32 */
  localPort?: number
  clientCertificate?: X509Certificate2
}

export interface ConstructorInfo {
  name?: string | null
  declaringType?: Type
  reflectedType?: Type
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  /** ReuseSlot=0,ReuseSlot=0,Private=1,FamANDAssem=2,Assembly=3,Family=4,FamORAssem=5,Public=6,MemberAccessMask=7,UnmanagedExport=8,Static=16,Final=32,Virtual=64,HideBySig=128,VtableLayoutMask=256,VtableLayoutMask=256,CheckAccessOnOverride=512,Abstract=1024,SpecialName=2048,RTSpecialName=4096,PinvokeImpl=8192,HasSecurity=16384,RequireSecObject=32768,ReservedMask=53248 */
  attributes?: MethodAttributes
  /** Managed=0,Managed=0,Native=1,OPTIL=2,CodeTypeMask=3,CodeTypeMask=3,Unmanaged=4,Unmanaged=4,NoInlining=8,ForwardRef=16,Synchronized=32,NoOptimization=64,PreserveSig=128,AggressiveInlining=256,AggressiveOptimization=512,InternalCall=4096,MaxMethodImplVal=65535 */
  methodImplementationFlags?: MethodImplAttributes
  /** Standard=1,VarArgs=2,Any=3,HasThis=32,ExplicitThis=64 */
  callingConvention?: CallingConventions
  isAbstract?: boolean
  isConstructor?: boolean
  isFinal?: boolean
  isHideBySig?: boolean
  isSpecialName?: boolean
  isStatic?: boolean
  isVirtual?: boolean
  isAssembly?: boolean
  isFamily?: boolean
  isFamilyAndAssembly?: boolean
  isFamilyOrAssembly?: boolean
  isPrivate?: boolean
  isPublic?: boolean
  isConstructedGenericMethod?: boolean
  isGenericMethod?: boolean
  isGenericMethodDefinition?: boolean
  containsGenericParameters?: boolean
  methodHandle?: RuntimeMethodHandle
  isSecurityCritical?: boolean
  isSecuritySafeCritical?: boolean
  isSecurityTransparent?: boolean
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
}

export interface CustomAttributeData {
  attributeType?: Type
  constructor?: ConstructorInfo
  constructorArguments?: CustomAttributeTypedArgument[] | null
  namedArguments?: CustomAttributeNamedArgument[] | null
}

export interface CustomAttributeNamedArgument {
  memberInfo?: MemberInfo
  typedValue?: CustomAttributeTypedArgument
  memberName?: string | null
  isField?: boolean
}

export interface CustomAttributeTypedArgument {
  argumentType?: Type
  value?: any
}

/** 添加字典 */
export interface DictAddInput {
  /**
   * 字典类型Id
   * @format int64
   */
  dictTypeId?: number
  /**
   * 字典名称
   * @minLength 1
   */
  name: string
  /** 字典编码 */
  code?: string | null
  /** 字典值 */
  value?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

export interface DictGetListDto {
  /** 字典类型编码 */
  dictTypeCode?: string | null
  /** 字典类型名称 */
  dictTypeName?: string | null
  /**
   * 主键Id
   * @format int64
   */
  id?: number
  /** 字典名称 */
  name?: string | null
  /** 字典编码 */
  code?: string | null
  /** 字典值 */
  value?: string | null
}

export interface DictGetOutput {
  /**
   * 字典类型Id
   * @format int64
   */
  dictTypeId?: number
  /**
   * 字典名称
   * @minLength 1
   */
  name: string
  /** 字典编码 */
  code?: string | null
  /** 字典值 */
  value?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

export interface DictGetPageDto {
  /** @format int64 */
  dictTypeId?: number
  name?: string | null
}

export interface DictGetPageOutput {
  /**
   * 主键Id
   * @format int64
   */
  id?: number
  /** 字典名称 */
  name?: string | null
  /** 字典编码 */
  code?: string | null
  /** 字典值 */
  value?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

/** 添加字典类型 */
export interface DictTypeAddInput {
  /**
   * 字典类型名称
   * @minLength 1
   */
  name: string
  /** 字典类型编码 */
  code?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

export interface DictTypeGetOutput {
  /**
   * 字典类型名称
   * @minLength 1
   */
  name: string
  /** 字典类型编码 */
  code?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

export interface DictTypeGetPageDto {
  name?: string | null
}

export interface DictTypeGetPageOutput {
  /**
   * 主键Id
   * @format int64
   */
  id?: number
  /** 字典名称 */
  name?: string | null
  /** 字典编码 */
  code?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

/** 修改 */
export interface DictTypeUpdateInput {
  /**
   * 字典类型名称
   * @minLength 1
   */
  name: string
  /** 字典类型编码 */
  code?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

/** 修改 */
export interface DictUpdateInput {
  /**
   * 字典类型Id
   * @format int64
   */
  dictTypeId?: number
  /**
   * 字典名称
   * @minLength 1
   */
  name: string
  /** 字典编码 */
  code?: string | null
  /** 字典值 */
  value?: string | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

export interface DynamicFilterInfo {
  field?: string | null
  /** Contains=0,StartsWith=1,EndsWith=2,NotContains=3,NotStartsWith=4,NotEndsWith=5,Equal=6,Equals=7,Eq=8,NotEqual=9,GreaterThan=10,GreaterThanOrEqual=11,LessThan=12,LessThanOrEqual=13,Range=14,DateRange=15,Any=16,NotAny=17,Custom=18 */
  operator?: DynamicFilterOperator
  value?: any
  /** And=0,Or=1 */
  logic?: DynamicFilterLogic
  filters?: DynamicFilterInfo[] | null
}

/**
 * And=0,Or=1
 * @format int32
 */
export type DynamicFilterLogic = 0 | 1

/**
 * Contains=0,StartsWith=1,EndsWith=2,NotContains=3,NotStartsWith=4,NotEndsWith=5,Equal=6,Equals=7,Eq=8,NotEqual=9,GreaterThan=10,GreaterThanOrEqual=11,LessThan=12,LessThanOrEqual=13,Range=14,DateRange=15,Any=16,NotAny=17,Custom=18
 * @format int32
 */
export type DynamicFilterOperator = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18

/**
 * None=0,SpecialName=512,ReservedMask=1024,ReservedMask=1024
 * @format int32
 */
export type EventAttributes = 0 | 512 | 1024

export interface EventInfo {
  name?: string | null
  declaringType?: Type
  reflectedType?: Type
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  /** None=0,SpecialName=512,ReservedMask=1024,ReservedMask=1024 */
  attributes?: EventAttributes
  isSpecialName?: boolean
  addMethod?: MethodInfo
  removeMethod?: MethodInfo
  raiseMethod?: MethodInfo
  isMulticast?: boolean
  eventHandlerType?: Type
}

/**
 * PrivateScope=0,Private=1,FamANDAssem=2,Assembly=3,Family=4,FamORAssem=5,Public=6,FieldAccessMask=7,Static=16,InitOnly=32,Literal=64,NotSerialized=128,HasFieldRVA=256,SpecialName=512,RTSpecialName=1024,HasFieldMarshal=4096,PinvokeImpl=8192,HasDefault=32768,ReservedMask=38144
 * @format int32
 */
export type FieldAttributes = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 16 | 32 | 64 | 128 | 256 | 512 | 1024 | 4096 | 8192 | 32768 | 38144

export interface FieldInfo {
  name?: string | null
  declaringType?: Type
  reflectedType?: Type
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  /** PrivateScope=0,Private=1,FamANDAssem=2,Assembly=3,Family=4,FamORAssem=5,Public=6,FieldAccessMask=7,Static=16,InitOnly=32,Literal=64,NotSerialized=128,HasFieldRVA=256,SpecialName=512,RTSpecialName=1024,HasFieldMarshal=4096,PinvokeImpl=8192,HasDefault=32768,ReservedMask=38144 */
  attributes?: FieldAttributes
  fieldType?: Type
  isInitOnly?: boolean
  isLiteral?: boolean
  isNotSerialized?: boolean
  isPinvokeImpl?: boolean
  isSpecialName?: boolean
  isStatic?: boolean
  isAssembly?: boolean
  isFamily?: boolean
  isFamilyAndAssembly?: boolean
  isFamilyOrAssembly?: boolean
  isPrivate?: boolean
  isPublic?: boolean
  isSecurityCritical?: boolean
  isSecuritySafeCritical?: boolean
  isSecurityTransparent?: boolean
  fieldHandle?: RuntimeFieldHandle
}

/**
 * None=0,Covariant=1,Contravariant=2,VarianceMask=3,ReferenceTypeConstraint=4,NotNullableValueTypeConstraint=8,DefaultConstructorConstraint=16,SpecialConstraintMask=28
 * @format int32
 */
export type GenericParameterAttributes = 0 | 1 | 2 | 3 | 4 | 8 | 16 | 28

export interface HostString {
  value?: string | null
  hasValue?: boolean
  host?: string | null
  /** @format int32 */
  port?: number | null
}

export interface HttpContext {
  features?: KeyValuePairTypeObject[] | null
  request?: HttpRequest
  response?: HttpResponse
  connection?: ConnectionInfo
  webSockets?: WebSocketManager
  user?: ClaimsPrincipal
  items?: Record<string, any>
  requestServices?: IServiceProvider
  requestAborted?: CancellationToken
  traceIdentifier?: string | null
  session?: ISession
}

export interface HttpRequest {
  httpContext?: HttpContext
  method?: string | null
  scheme?: string | null
  isHttps?: boolean
  host?: HostString
  pathBase?: PathString
  path?: PathString
  queryString?: QueryString
  query?: KeyValuePairStringStringValues[] | null
  protocol?: string | null
  headers?: Record<string, string[]>
  cookies?: KeyValuePairStringString[] | null
  /** @format int64 */
  contentLength?: number | null
  contentType?: string | null
  body?: Stream
  bodyReader?: PipeReader
  hasFormContentType?: boolean
  form?: KeyValuePairStringStringValues[] | null
  routeValues?: Record<string, any>
}

export interface HttpResponse {
  httpContext?: HttpContext
  /** @format int32 */
  statusCode?: number
  headers?: Record<string, string[]>
  body?: Stream
  bodyWriter?: PipeWriter
  /** @format int64 */
  contentLength?: number | null
  contentType?: string | null
  cookies?: IResponseCookies
  hasStarted?: boolean
}

export type ICustomAttributeProvider = object

export interface IIdentity {
  name?: string | null
  authenticationType?: string | null
  isAuthenticated?: boolean
}

export interface IPAddress {
  /** Unspecified=0,Unix=1,InterNetwork=2,ImpLink=3,Pup=4,Chaos=5,Ipx=6,Ipx=6,Iso=7,Iso=7,Ecma=8,DataKit=9,Ccitt=10,Sna=11,DecNet=12,DataLink=13,Lat=14,HyperChannel=15,AppleTalk=16,NetBios=17,VoiceView=18,FireFox=19,Banyan=21,Atm=22,InterNetworkV6=23,Cluster=24,Ieee12844=25,Irda=26,NetworkDesigners=28,Max=29,Packet=65536,ControllerAreaNetwork=65537,Unknown=-1 */
  addressFamily?: AddressFamily
  /** @format int64 */
  scopeId?: number
  isIPv6Multicast?: boolean
  isIPv6LinkLocal?: boolean
  isIPv6SiteLocal?: boolean
  isIPv6Teredo?: boolean
  isIPv6UniqueLocal?: boolean
  isIPv4MappedToIPv6?: boolean
  /**
   * @deprecated
   * @format int64
   */
  address?: number
}

export type IResponseCookies = object

export type IServiceProvider = object

export interface ISession {
  isAvailable?: boolean
  id?: string | null
  keys?: string[] | null
}

export type IntPtr = object

export interface KeySizes {
  /** @format int32 */
  minSize?: number
  /** @format int32 */
  maxSize?: number
  /** @format int32 */
  skipSize?: number
}

export interface KeyValuePairStringString {
  key?: string | null
  value?: string | null
}

export interface KeyValuePairStringStringValues {
  key?: string | null
  value?: string[]
}

export interface KeyValuePairTypeObject {
  key?: Type
  value?: any
}

/**
 * Sequential=0,Explicit=2,Auto=3
 * @format int32
 */
export type LayoutKind = 0 | 2 | 3

export interface LogGetPageDto {
  createdUserName?: string | null
}

/** 添加 */
export interface LoginLogAddInput {
  /** 姓名 */
  name?: string | null
  /** IP */
  ip?: string | null
  /** 浏览器 */
  browser?: string | null
  /** 操作系统 */
  os?: string | null
  /** 设备 */
  device?: string | null
  /** 浏览器信息 */
  browserInfo?: string | null
  /**
   * 耗时（毫秒）
   * @format int64
   */
  elapsedMilliseconds?: number
  /** 操作状态 */
  status?: boolean | null
  /** 操作消息 */
  msg?: string | null
  /** 操作结果 */
  result?: string | null
  /**
   * 创建者Id
   * @format int64
   */
  createdUserId?: number | null
  /** 创建者 */
  createdUserName?: string | null
}

export interface LoginLogListOutput {
  /**
   * 编号
   * @format int64
   */
  id?: number
  /** 昵称 */
  nickName?: string | null
  /** 创建者 */
  createdUserName?: string | null
  /** IP */
  ip?: string | null
  /** 浏览器 */
  browser?: string | null
  /** 操作系统 */
  os?: string | null
  /** 设备 */
  device?: string | null
  /**
   * 耗时（毫秒）
   * @format int64
   */
  elapsedMilliseconds?: number
  /** 操作状态 */
  status?: boolean
  /** 操作消息 */
  msg?: string | null
  /**
   * 创建时间
   * @format date-time
   */
  createdTime?: string | null
}

export interface MemberInfo {
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  declaringType?: Type
  reflectedType?: Type
  name?: string | null
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
}

/**
 * Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191
 * @format int32
 */
export type MemberTypes = 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128 | 191

/**
 * ReuseSlot=0,ReuseSlot=0,Private=1,FamANDAssem=2,Assembly=3,Family=4,FamORAssem=5,Public=6,MemberAccessMask=7,UnmanagedExport=8,Static=16,Final=32,Virtual=64,HideBySig=128,VtableLayoutMask=256,VtableLayoutMask=256,CheckAccessOnOverride=512,Abstract=1024,SpecialName=2048,RTSpecialName=4096,PinvokeImpl=8192,HasSecurity=16384,RequireSecObject=32768,ReservedMask=53248
 * @format int32
 */
export type MethodAttributes = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 16 | 32 | 64 | 128 | 256 | 512 | 1024 | 2048 | 4096 | 8192 | 16384 | 32768 | 53248

export interface MethodBase {
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  name?: string | null
  declaringType?: Type
  reflectedType?: Type
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  /** ReuseSlot=0,ReuseSlot=0,Private=1,FamANDAssem=2,Assembly=3,Family=4,FamORAssem=5,Public=6,MemberAccessMask=7,UnmanagedExport=8,Static=16,Final=32,Virtual=64,HideBySig=128,VtableLayoutMask=256,VtableLayoutMask=256,CheckAccessOnOverride=512,Abstract=1024,SpecialName=2048,RTSpecialName=4096,PinvokeImpl=8192,HasSecurity=16384,RequireSecObject=32768,ReservedMask=53248 */
  attributes?: MethodAttributes
  /** Managed=0,Managed=0,Native=1,OPTIL=2,CodeTypeMask=3,CodeTypeMask=3,Unmanaged=4,Unmanaged=4,NoInlining=8,ForwardRef=16,Synchronized=32,NoOptimization=64,PreserveSig=128,AggressiveInlining=256,AggressiveOptimization=512,InternalCall=4096,MaxMethodImplVal=65535 */
  methodImplementationFlags?: MethodImplAttributes
  /** Standard=1,VarArgs=2,Any=3,HasThis=32,ExplicitThis=64 */
  callingConvention?: CallingConventions
  isAbstract?: boolean
  isConstructor?: boolean
  isFinal?: boolean
  isHideBySig?: boolean
  isSpecialName?: boolean
  isStatic?: boolean
  isVirtual?: boolean
  isAssembly?: boolean
  isFamily?: boolean
  isFamilyAndAssembly?: boolean
  isFamilyOrAssembly?: boolean
  isPrivate?: boolean
  isPublic?: boolean
  isConstructedGenericMethod?: boolean
  isGenericMethod?: boolean
  isGenericMethodDefinition?: boolean
  containsGenericParameters?: boolean
  methodHandle?: RuntimeMethodHandle
  isSecurityCritical?: boolean
  isSecuritySafeCritical?: boolean
  isSecurityTransparent?: boolean
}

/**
 * Managed=0,Managed=0,Native=1,OPTIL=2,CodeTypeMask=3,CodeTypeMask=3,Unmanaged=4,Unmanaged=4,NoInlining=8,ForwardRef=16,Synchronized=32,NoOptimization=64,PreserveSig=128,AggressiveInlining=256,AggressiveOptimization=512,InternalCall=4096,MaxMethodImplVal=65535
 * @format int32
 */
export type MethodImplAttributes = 0 | 1 | 2 | 3 | 4 | 8 | 16 | 32 | 64 | 128 | 256 | 512 | 4096 | 65535

export interface MethodInfo {
  name?: string | null
  declaringType?: Type
  reflectedType?: Type
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  /** ReuseSlot=0,ReuseSlot=0,Private=1,FamANDAssem=2,Assembly=3,Family=4,FamORAssem=5,Public=6,MemberAccessMask=7,UnmanagedExport=8,Static=16,Final=32,Virtual=64,HideBySig=128,VtableLayoutMask=256,VtableLayoutMask=256,CheckAccessOnOverride=512,Abstract=1024,SpecialName=2048,RTSpecialName=4096,PinvokeImpl=8192,HasSecurity=16384,RequireSecObject=32768,ReservedMask=53248 */
  attributes?: MethodAttributes
  /** Managed=0,Managed=0,Native=1,OPTIL=2,CodeTypeMask=3,CodeTypeMask=3,Unmanaged=4,Unmanaged=4,NoInlining=8,ForwardRef=16,Synchronized=32,NoOptimization=64,PreserveSig=128,AggressiveInlining=256,AggressiveOptimization=512,InternalCall=4096,MaxMethodImplVal=65535 */
  methodImplementationFlags?: MethodImplAttributes
  /** Standard=1,VarArgs=2,Any=3,HasThis=32,ExplicitThis=64 */
  callingConvention?: CallingConventions
  isAbstract?: boolean
  isConstructor?: boolean
  isFinal?: boolean
  isHideBySig?: boolean
  isSpecialName?: boolean
  isStatic?: boolean
  isVirtual?: boolean
  isAssembly?: boolean
  isFamily?: boolean
  isFamilyAndAssembly?: boolean
  isFamilyOrAssembly?: boolean
  isPrivate?: boolean
  isPublic?: boolean
  isConstructedGenericMethod?: boolean
  isGenericMethod?: boolean
  isGenericMethodDefinition?: boolean
  containsGenericParameters?: boolean
  methodHandle?: RuntimeMethodHandle
  isSecurityCritical?: boolean
  isSecuritySafeCritical?: boolean
  isSecurityTransparent?: boolean
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  returnParameter?: ParameterInfo
  returnType?: Type
  returnTypeCustomAttributes?: ICustomAttributeProvider
}

export interface Module {
  assembly?: Assembly
  fullyQualifiedName?: string | null
  name?: string | null
  /** @format int32 */
  mdStreamVersion?: number
  /** @format uuid */
  moduleVersionId?: string
  scopeName?: string | null
  moduleHandle?: ModuleHandle
  customAttributes?: CustomAttributeData[] | null
  /** @format int32 */
  metadataToken?: number
}

export interface ModuleHandle {
  /** @format int32 */
  mdStreamVersion?: number
}

export interface Oid {
  value?: string | null
  friendlyName?: string | null
}

/** 添加 */
export interface OprationLogAddInput {
  /** 姓名 */
  name?: string | null
  /** 接口名称 */
  apiLabel?: string | null
  /** 接口地址 */
  apiPath?: string | null
  /** 接口提交方法 */
  apiMethod?: string | null
  /** IP */
  ip?: string | null
  /** 浏览器 */
  browser?: string | null
  /** 操作系统 */
  os?: string | null
  /** 设备 */
  device?: string | null
  /** 浏览器信息 */
  browserInfo?: string | null
  /**
   * 耗时（毫秒）
   * @format int64
   */
  elapsedMilliseconds?: number
  /** 操作状态 */
  status?: boolean | null
  /** 操作消息 */
  msg?: string | null
  /** 操作参数 */
  params?: string | null
  /** 操作结果 */
  result?: string | null
}

export interface OprationLogListOutput {
  /**
   * 编号
   * @format int64
   */
  id?: number
  /** 昵称 */
  nickName?: string | null
  /** 创建者 */
  createdUserName?: string | null
  /** 接口名称 */
  apiLabel?: string | null
  /** 接口地址 */
  apiPath?: string | null
  /** 接口提交方法 */
  apiMethod?: string | null
  /** IP */
  ip?: string | null
  /** 浏览器 */
  browser?: string | null
  /** 操作系统 */
  os?: string | null
  /** 设备 */
  device?: string | null
  /**
   * 耗时（毫秒）
   * @format int64
   */
  elapsedMilliseconds?: number
  /** 操作状态 */
  status?: boolean
  /** 操作消息 */
  msg?: string | null
  /**
   * 创建时间
   * @format date-time
   */
  createdTime?: string | null
}

export interface PageInputApiGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: ApiGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputConfigGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: ConfigGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputDictGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: DictGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputDictTypeGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: DictTypeGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputLogGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: LogGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputPkgGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: PkgGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputRoleGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  filter?: RoleGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageInputUserGetPageDto {
  /** @format int32 */
  currentPage?: number
  /** @format int32 */
  pageSize?: number
  /** 用户分页查询条件 */
  filter?: UserGetPageDto
  dynamicFilter?: DynamicFilterInfo
}

export interface PageOutputApiEntity {
  /** @format int64 */
  total?: number
  list?: ApiEntity[] | null
}

export interface PageOutputConfigGetPageOutput {
  /** @format int64 */
  total?: number
  list?: ConfigGetPageOutput[] | null
}

export interface PageOutputDictGetPageOutput {
  /** @format int64 */
  total?: number
  list?: DictGetPageOutput[] | null
}

export interface PageOutputDictTypeGetPageOutput {
  /** @format int64 */
  total?: number
  list?: DictTypeGetPageOutput[] | null
}

export interface PageOutputLoginLogListOutput {
  /** @format int64 */
  total?: number
  list?: LoginLogListOutput[] | null
}

export interface PageOutputOprationLogListOutput {
  /** @format int64 */
  total?: number
  list?: OprationLogListOutput[] | null
}

export interface PageOutputPkgGetPageOutput {
  /** @format int64 */
  total?: number
  list?: PkgGetPageOutput[] | null
}

export interface PageOutputRoleGetPageOutput {
  /** @format int64 */
  total?: number
  list?: RoleGetPageOutput[] | null
}

export interface PageOutputUserGetPageOutput {
  /** @format int64 */
  total?: number
  list?: UserGetPageOutput[] | null
}

/**
 * None=0,In=1,Out=2,Lcid=4,Retval=8,Optional=16,HasDefault=4096,HasFieldMarshal=8192,Reserved3=16384,Reserved4=32768,ReservedMask=61440
 * @format int32
 */
export type ParameterAttributes = 0 | 1 | 2 | 4 | 8 | 16 | 4096 | 8192 | 16384 | 32768 | 61440

export interface ParameterInfo {
  /** None=0,In=1,Out=2,Lcid=4,Retval=8,Optional=16,HasDefault=4096,HasFieldMarshal=8192,Reserved3=16384,Reserved4=32768,ReservedMask=61440 */
  attributes?: ParameterAttributes
  member?: MemberInfo
  name?: string | null
  parameterType?: Type
  /** @format int32 */
  position?: number
  isIn?: boolean
  isLcid?: boolean
  isOptional?: boolean
  isOut?: boolean
  isRetval?: boolean
  defaultValue?: any
  rawDefaultValue?: any
  hasDefaultValue?: boolean
  customAttributes?: CustomAttributeData[] | null
  /** @format int32 */
  metadataToken?: number
}

export interface PathString {
  value?: string | null
  hasValue?: boolean
}

export interface PermissionAddApiInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 接口
   * @format int64
   */
  apiId?: number | null
  /** 权限名称 */
  label?: string | null
  /** 权限编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

export interface PermissionAddDotInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /** 关联接口 */
  apiIds?: number[] | null
  /** 权限名称 */
  label?: string | null
  /** 权限编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 图标 */
  icon?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

export interface PermissionAddGroupInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 视图
   * @format int64
   */
  viewId?: number | null
  /** 路由命名 */
  name?: string | null
  /** 访问路由地址 */
  path?: string | null
  /** 重定向地址 */
  redirect?: string | null
  /** 权限名称 */
  label?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /** 展开 */
  opened?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

export interface PermissionAddMenuInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 视图
   * @format int64
   */
  viewId?: number | null
  /** 路由命名 */
  name?: string | null
  /** 路由地址 */
  path?: string | null
  /** 权限名称 */
  label?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /** 打开新窗口 */
  newWindow?: boolean
  /** 链接外显 */
  external?: boolean
  /** 是否缓存 */
  isKeepAlive?: boolean
  /** 是否固定 */
  isAffix?: boolean
  /** 链接地址 */
  link?: string | null
  /** 是否内嵌窗口 */
  isIframe?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

export interface PermissionAssignInput {
  /** @format int64 */
  roleId: number
  permissionIds: number[]
}

export interface PermissionEntity {
  /** @format int64 */
  id?: number
  /** @format int64 */
  createdUserId?: number | null
  /** @maxLength 50 */
  createdUserName?: string | null
  /** @format date-time */
  createdTime?: string | null
  /** @format int64 */
  modifiedUserId?: number | null
  /** @maxLength 50 */
  modifiedUserName?: string | null
  /** @format date-time */
  modifiedTime?: string | null
  isDeleted?: boolean
  /** @format int64 */
  parentId?: number
  label?: string | null
  code?: string | null
  /** Group=1,Menu=2,Dot=3 */
  type?: PermissionType
  /** @format int64 */
  viewId?: number | null
  view?: ViewEntity
  name?: string | null
  path?: string | null
  redirect?: string | null
  icon?: string | null
  hidden?: boolean
  opened?: boolean
  newWindow?: boolean
  external?: boolean
  isKeepAlive?: boolean
  isAffix?: boolean
  link?: string | null
  isIframe?: boolean
  /** @format int32 */
  sort?: number
  description?: string | null
  enabled?: boolean
  apis?: ApiEntity[] | null
  childs?: PermissionEntity[] | null
}

export interface PermissionGetApiOutput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 接口
   * @format int64
   */
  apiId?: number | null
  /** 权限名称 */
  label?: string | null
  /** 权限编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionGetDotOutput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /** 关联接口 */
  apiIds?: number[] | null
  /** 权限名称 */
  label?: string | null
  /** 权限编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 图标 */
  icon?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionGetGroupOutput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 视图
   * @format int64
   */
  viewId?: number | null
  /** 路由命名 */
  name?: string | null
  /** 访问路由地址 */
  path?: string | null
  /** 重定向地址 */
  redirect?: string | null
  /** 权限名称 */
  label?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /** 展开 */
  opened?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionGetMenuOutput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 视图
   * @format int64
   */
  viewId?: number | null
  /** 路由命名 */
  name?: string | null
  /** 路由地址 */
  path?: string | null
  /** 权限名称 */
  label?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /** 打开新窗口 */
  newWindow?: boolean
  /** 链接外显 */
  external?: boolean
  /** 是否缓存 */
  isKeepAlive?: boolean
  /** 是否固定 */
  isAffix?: boolean
  /** 链接地址 */
  link?: string | null
  /** 是否内嵌窗口 */
  isIframe?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionListOutput {
  /**
   * 权限Id
   * @format int64
   */
  id?: number
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /** 权限名称 */
  label?: string | null
  /** Group=1,Menu=2,Dot=3 */
  type?: PermissionType
  /** 路由地址 */
  path?: string | null
  /** 重定向地址 */
  redirect?: string | null
  /** 视图地址 */
  viewPath?: string | null
  /** 链接地址 */
  link?: string | null
  /** 接口路径 */
  apiPaths?: string | null
  /** 图标 */
  icon?: string | null
  /** 展开 */
  opened?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number | null
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
}

/**
 * Group=1,Menu=2,Dot=3
 * @format int32
 */
export type PermissionType = 1 | 2 | 3

export interface PermissionUpdateApiInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 接口
   * @format int64
   */
  apiId?: number | null
  /** 权限名称 */
  label?: string | null
  /** 权限编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionUpdateDotInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /** 关联接口 */
  apiIds?: number[] | null
  /** 权限名称 */
  label?: string | null
  /** 权限编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 图标 */
  icon?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionUpdateGroupInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 视图
   * @format int64
   */
  viewId?: number | null
  /** 路由命名 */
  name?: string | null
  /** 访问路由地址 */
  path?: string | null
  /** 重定向地址 */
  redirect?: string | null
  /** 权限名称 */
  label?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /** 展开 */
  opened?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export interface PermissionUpdateMenuInput {
  /**
   * 父级节点
   * @format int64
   */
  parentId?: number
  /**
   * 视图
   * @format int64
   */
  viewId?: number | null
  /** 路由命名 */
  name?: string | null
  /** 路由地址 */
  path?: string | null
  /** 权限名称 */
  label?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /** 图标 */
  icon?: string | null
  /** 打开新窗口 */
  newWindow?: boolean
  /** 链接外显 */
  external?: boolean
  /** 是否缓存 */
  isKeepAlive?: boolean
  /** 是否固定 */
  isAffix?: boolean
  /** 链接地址 */
  link?: string | null
  /** 是否内嵌窗口 */
  isIframe?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 权限Id
   * @format int64
   */
  id: number
}

export type PipeReader = object

export interface PipeWriter {
  canGetUnflushedBytes?: boolean
  /** @format int64 */
  unflushedBytes?: number
}

/** 添加 */
export interface PkgAddInput {
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

/** 添加套餐租户列表 */
export interface PkgAddPkgTenantListInput {
  /**
   * 套餐
   * @format int64
   */
  pkgId: number
}

export interface PkgGetListOutput {
  /**
   * 主键
   * @format int64
   */
  id?: number
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 描述 */
  description?: string | null
  /** 启用 */
  enabled?: boolean
  /**
   * 创建时间
   * @format date-time
   */
  createdTime?: string | null
}

export interface PkgGetOutput {
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 套餐Id
   * @format int64
   */
  id: number
}

export interface PkgGetPageDto {
  /** 名称 */
  name?: string | null
}

export interface PkgGetPageOutput {
  /**
   * 主键
   * @format int64
   */
  id?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 创建时间
   * @format date-time
   */
  createdTime?: string | null
}

export interface PkgSetPkgPermissionsInput {
  /** @format int64 */
  pkgId: number
  permissionIds: number[]
}

/** 修改 */
export interface PkgUpdateInput {
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 套餐Id
   * @format int64
   */
  id: number
}

/**
 * None=0,SpecialName=512,RTSpecialName=1024,HasDefault=4096,Reserved2=8192,Reserved3=16384,Reserved4=32768,ReservedMask=62464
 * @format int32
 */
export type PropertyAttributes = 0 | 512 | 1024 | 4096 | 8192 | 16384 | 32768 | 62464

export interface PropertyInfo {
  name?: string | null
  declaringType?: Type
  reflectedType?: Type
  module?: Module
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  propertyType?: Type
  /** None=0,SpecialName=512,RTSpecialName=1024,HasDefault=4096,Reserved2=8192,Reserved3=16384,Reserved4=32768,ReservedMask=62464 */
  attributes?: PropertyAttributes
  isSpecialName?: boolean
  canRead?: boolean
  canWrite?: boolean
  getMethod?: MethodInfo
  setMethod?: MethodInfo
}

export interface PublicKey {
  encodedKeyValue?: AsnEncodedData
  encodedParameters?: AsnEncodedData
  key?: AsymmetricAlgorithm
  oid?: Oid
}

export interface QueryString {
  value?: string | null
  hasValue?: boolean
}

export interface ResultOutputApiGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: ApiGetOutput
}

export interface ResultOutputAuthGetPasswordEncryptKeyOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: AuthGetPasswordEncryptKeyOutput
}

export interface ResultOutputAuthGetUserInfoOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: AuthGetUserInfoOutput
}

export interface ResultOutputAuthGetUserPermissionsOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: AuthGetUserPermissionsOutput
}

export interface ResultOutputAuthUserProfileDto {
  success?: boolean
  code?: string | null
  msg?: string | null
  /** 用户个人信息 */
  data?: AuthUserProfileDto
}

export interface ResultOutputCaptchaData {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: CaptchaData
}

export interface ResultOutputConfigGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: ConfigGetOutput
}

export interface ResultOutputDictGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: DictGetOutput
}

export interface ResultOutputDictTypeGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: DictTypeGetOutput
}

export interface ResultOutputDictionaryStringListDictGetListDto {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: Record<string, DictGetListDto[]>
}

export interface ResultOutputIEnumerableObject {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: any[] | null
}

export interface ResultOutputIListUserPermissionsOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: UserPermissionsOutput[] | null
}

export interface ResultOutputInt64 {
  success?: boolean
  code?: string | null
  msg?: string | null
  /** @format int64 */
  data?: number
}

export interface ResultOutputListApiListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: ApiListOutput[] | null
}

export interface ResultOutputListAuthUserMenuDto {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: AuthUserMenuDto[] | null
}

export interface ResultOutputListInt64 {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: number[] | null
}

export interface ResultOutputListObject {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: any[] | null
}

export interface ResultOutputListPermissionListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PermissionListOutput[] | null
}

export interface ResultOutputListPkgGetListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PkgGetListOutput[] | null
}

export interface ResultOutputListRoleGetListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: RoleGetListOutput[] | null
}

export interface ResultOutputListRoleGetRoleUserListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: RoleGetRoleUserListOutput[] | null
}

export interface ResultOutputListViewListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: ViewListOutput[] | null
}

export interface ResultOutputObject {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: any
}

export interface ResultOutputPageOutputApiEntity {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputApiEntity
}

export interface ResultOutputPageOutputConfigGetPageOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputConfigGetPageOutput
}

export interface ResultOutputPageOutputDictGetPageOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputDictGetPageOutput
}

export interface ResultOutputPageOutputDictTypeGetPageOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputDictTypeGetPageOutput
}

export interface ResultOutputPageOutputLoginLogListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputLoginLogListOutput
}

export interface ResultOutputPageOutputOprationLogListOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputOprationLogListOutput
}

export interface ResultOutputPageOutputPkgGetPageOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputPkgGetPageOutput
}

export interface ResultOutputPageOutputRoleGetPageOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputRoleGetPageOutput
}

export interface ResultOutputPageOutputUserGetPageOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PageOutputUserGetPageOutput
}

export interface ResultOutputPermissionGetApiOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PermissionGetApiOutput
}

export interface ResultOutputPermissionGetDotOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PermissionGetDotOutput
}

export interface ResultOutputPermissionGetGroupOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PermissionGetGroupOutput
}

export interface ResultOutputPermissionGetMenuOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PermissionGetMenuOutput
}

export interface ResultOutputPkgGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: PkgGetOutput
}

export interface ResultOutputRoleGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: RoleGetOutput
}

export interface ResultOutputString {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: string | null
}

export interface ResultOutputUserGetBasicOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: UserGetBasicOutput
}

export interface ResultOutputUserGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: UserGetOutput
}

export interface ResultOutputValidateResult {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: ValidateResult
}

export interface ResultOutputViewGetOutput {
  success?: boolean
  code?: string | null
  msg?: string | null
  data?: ViewGetOutput
}

/** 添加 */
export interface RoleAddInput {
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** Group=1,Role=2 */
  type?: RoleType
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
}

/** 添加角色用户列表 */
export interface RoleAddRoleUserListInput {
  /**
   * 角色
   * @format int64
   */
  roleId: number
  /** 用户 */
  userIds?: number[] | null
}

export interface RoleGetListOutput {
  /**
   * 主键
   * @format int64
   */
  id?: number
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** Group=1,Role=2 */
  type?: RoleType
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 描述 */
  description?: string | null
}

export interface RoleGetOutput {
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** Group=1,Role=2 */
  type?: RoleType
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 角色Id
   * @format int64
   */
  id: number
}

export interface RoleGetPageDto {
  name?: string | null
}

export interface RoleGetPageOutput {
  /**
   * 主键
   * @format int64
   */
  id?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** 说明 */
  description?: string | null
  /** 隐藏 */
  hidden?: boolean
  /**
   * 创建时间
   * @format date-time
   */
  createdTime?: string | null
}

export interface RoleGetRoleUserListOutput {
  /**
   * 主键Id
   * @format int64
   */
  id?: number
  /** 姓名 */
  name?: string | null
  /** 手机号 */
  mobile?: string | null
}

/**
 * Group=1,Role=2
 * @format int32
 */
export type RoleType = 1 | 2

/** 修改 */
export interface RoleUpdateInput {
  /**
   * 父级Id
   * @format int64
   */
  parentId?: number
  /** 名称 */
  name?: string | null
  /** 编码 */
  code?: string | null
  /** Group=1,Role=2 */
  type?: RoleType
  /** 说明 */
  description?: string | null
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /**
   * 角色Id
   * @format int64
   */
  id: number
}

export interface RuntimeFieldHandle {
  value?: IntPtr
}

export interface RuntimeMethodHandle {
  value?: IntPtr
}

export interface RuntimeTypeHandle {
  value?: IntPtr
}

export interface SafeWaitHandle {
  isClosed?: boolean
  isInvalid?: boolean
}

/**
 * None=0,Level1=1,Level2=2
 * @format int32
 */
export type SecurityRuleSet = 0 | 1 | 2

export interface SlideTrack {
  /** @format int32 */
  backgroundImageWidth?: number
  /** @format int32 */
  backgroundImageHeight?: number
  /** @format int32 */
  sliderImageWidth?: number
  /** @format int32 */
  sliderImageHeight?: number
  /** @format date-time */
  startTime?: string
  /** @format date-time */
  endTime?: string
  tracks?: Track[] | null
  /** @format float */
  percent?: number
}

export interface Stream {
  canRead?: boolean
  canWrite?: boolean
  canSeek?: boolean
  canTimeout?: boolean
  /** @format int64 */
  length?: number
  /** @format int64 */
  position?: number
  /** @format int32 */
  readTimeout?: number
  /** @format int32 */
  writeTimeout?: number
}

export interface StructLayoutAttribute {
  typeId?: any
  /** Sequential=0,Explicit=2,Auto=3 */
  value?: LayoutKind
}

export interface Track {
  /** @format int32 */
  x?: number
  /** @format int32 */
  y?: number
  /** @format int32 */
  t?: number
}

export interface Type {
  name?: string | null
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  isInterface?: boolean
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  namespace?: string | null
  assemblyQualifiedName?: string | null
  fullName?: string | null
  assembly?: Assembly
  module?: Module
  isNested?: boolean
  declaringType?: Type
  declaringMethod?: MethodBase
  reflectedType?: Type
  underlyingSystemType?: Type
  isTypeDefinition?: boolean
  isArray?: boolean
  isByRef?: boolean
  isPointer?: boolean
  isConstructedGenericType?: boolean
  isGenericParameter?: boolean
  isGenericTypeParameter?: boolean
  isGenericMethodParameter?: boolean
  isGenericType?: boolean
  isGenericTypeDefinition?: boolean
  isSZArray?: boolean
  isVariableBoundArray?: boolean
  isByRefLike?: boolean
  hasElementType?: boolean
  genericTypeArguments?: Type[] | null
  /** @format int32 */
  genericParameterPosition?: number
  /** None=0,Covariant=1,Contravariant=2,VarianceMask=3,ReferenceTypeConstraint=4,NotNullableValueTypeConstraint=8,DefaultConstructorConstraint=16,SpecialConstraintMask=28 */
  genericParameterAttributes?: GenericParameterAttributes
  /** NotPublic=0,NotPublic=0,NotPublic=0,NotPublic=0,Public=1,NestedPublic=2,NestedPrivate=3,NestedFamily=4,NestedAssembly=5,NestedFamANDAssem=6,VisibilityMask=7,VisibilityMask=7,SequentialLayout=8,ExplicitLayout=16,LayoutMask=24,ClassSemanticsMask=32,ClassSemanticsMask=32,Abstract=128,Sealed=256,SpecialName=1024,RTSpecialName=2048,Import=4096,Serializable=8192,WindowsRuntime=16384,UnicodeClass=65536,AutoClass=131072,StringFormatMask=196608,StringFormatMask=196608,HasSecurity=262144,ReservedMask=264192,BeforeFieldInit=1048576,CustomFormatMask=12582912 */
  attributes?: TypeAttributes
  isAbstract?: boolean
  isImport?: boolean
  isSealed?: boolean
  isSpecialName?: boolean
  isClass?: boolean
  isNestedAssembly?: boolean
  isNestedFamANDAssem?: boolean
  isNestedFamily?: boolean
  isNestedFamORAssem?: boolean
  isNestedPrivate?: boolean
  isNestedPublic?: boolean
  isNotPublic?: boolean
  isPublic?: boolean
  isAutoLayout?: boolean
  isExplicitLayout?: boolean
  isLayoutSequential?: boolean
  isAnsiClass?: boolean
  isAutoClass?: boolean
  isUnicodeClass?: boolean
  isCOMObject?: boolean
  isContextful?: boolean
  isEnum?: boolean
  isMarshalByRef?: boolean
  isPrimitive?: boolean
  isValueType?: boolean
  isSignatureType?: boolean
  isSecurityCritical?: boolean
  isSecuritySafeCritical?: boolean
  isSecurityTransparent?: boolean
  structLayoutAttribute?: StructLayoutAttribute
  typeInitializer?: ConstructorInfo
  typeHandle?: RuntimeTypeHandle
  /** @format uuid */
  guid?: string
  baseType?: Type
  isSerializable?: boolean
  containsGenericParameters?: boolean
  isVisible?: boolean
}

/**
 * NotPublic=0,NotPublic=0,NotPublic=0,NotPublic=0,Public=1,NestedPublic=2,NestedPrivate=3,NestedFamily=4,NestedAssembly=5,NestedFamANDAssem=6,VisibilityMask=7,VisibilityMask=7,SequentialLayout=8,ExplicitLayout=16,LayoutMask=24,ClassSemanticsMask=32,ClassSemanticsMask=32,Abstract=128,Sealed=256,SpecialName=1024,RTSpecialName=2048,Import=4096,Serializable=8192,WindowsRuntime=16384,UnicodeClass=65536,AutoClass=131072,StringFormatMask=196608,StringFormatMask=196608,HasSecurity=262144,ReservedMask=264192,BeforeFieldInit=1048576,CustomFormatMask=12582912
 * @format int32
 */
export type TypeAttributes =
  | 0
  | 1
  | 2
  | 3
  | 4
  | 5
  | 6
  | 7
  | 8
  | 16
  | 24
  | 32
  | 128
  | 256
  | 1024
  | 2048
  | 4096
  | 8192
  | 16384
  | 65536
  | 131072
  | 196608
  | 262144
  | 264192
  | 1048576
  | 12582912

export interface TypeInfo {
  name?: string | null
  customAttributes?: CustomAttributeData[] | null
  isCollectible?: boolean
  /** @format int32 */
  metadataToken?: number
  isInterface?: boolean
  /** Constructor=1,Event=2,Field=4,Method=8,Property=16,TypeInfo=32,Custom=64,NestedType=128,All=191 */
  memberType?: MemberTypes
  namespace?: string | null
  assemblyQualifiedName?: string | null
  fullName?: string | null
  assembly?: Assembly
  module?: Module
  isNested?: boolean
  declaringType?: Type
  declaringMethod?: MethodBase
  reflectedType?: Type
  underlyingSystemType?: Type
  isTypeDefinition?: boolean
  isArray?: boolean
  isByRef?: boolean
  isPointer?: boolean
  isConstructedGenericType?: boolean
  isGenericParameter?: boolean
  isGenericTypeParameter?: boolean
  isGenericMethodParameter?: boolean
  isGenericType?: boolean
  isGenericTypeDefinition?: boolean
  isSZArray?: boolean
  isVariableBoundArray?: boolean
  isByRefLike?: boolean
  hasElementType?: boolean
  genericTypeArguments?: Type[] | null
  /** @format int32 */
  genericParameterPosition?: number
  /** None=0,Covariant=1,Contravariant=2,VarianceMask=3,ReferenceTypeConstraint=4,NotNullableValueTypeConstraint=8,DefaultConstructorConstraint=16,SpecialConstraintMask=28 */
  genericParameterAttributes?: GenericParameterAttributes
  /** NotPublic=0,NotPublic=0,NotPublic=0,NotPublic=0,Public=1,NestedPublic=2,NestedPrivate=3,NestedFamily=4,NestedAssembly=5,NestedFamANDAssem=6,VisibilityMask=7,VisibilityMask=7,SequentialLayout=8,ExplicitLayout=16,LayoutMask=24,ClassSemanticsMask=32,ClassSemanticsMask=32,Abstract=128,Sealed=256,SpecialName=1024,RTSpecialName=2048,Import=4096,Serializable=8192,WindowsRuntime=16384,UnicodeClass=65536,AutoClass=131072,StringFormatMask=196608,StringFormatMask=196608,HasSecurity=262144,ReservedMask=264192,BeforeFieldInit=1048576,CustomFormatMask=12582912 */
  attributes?: TypeAttributes
  isAbstract?: boolean
  isImport?: boolean
  isSealed?: boolean
  isSpecialName?: boolean
  isClass?: boolean
  isNestedAssembly?: boolean
  isNestedFamANDAssem?: boolean
  isNestedFamily?: boolean
  isNestedFamORAssem?: boolean
  isNestedPrivate?: boolean
  isNestedPublic?: boolean
  isNotPublic?: boolean
  isPublic?: boolean
  isAutoLayout?: boolean
  isExplicitLayout?: boolean
  isLayoutSequential?: boolean
  isAnsiClass?: boolean
  isAutoClass?: boolean
  isUnicodeClass?: boolean
  isCOMObject?: boolean
  isContextful?: boolean
  isEnum?: boolean
  isMarshalByRef?: boolean
  isPrimitive?: boolean
  isValueType?: boolean
  isSignatureType?: boolean
  isSecurityCritical?: boolean
  isSecuritySafeCritical?: boolean
  isSecurityTransparent?: boolean
  structLayoutAttribute?: StructLayoutAttribute
  typeInitializer?: ConstructorInfo
  typeHandle?: RuntimeTypeHandle
  /** @format uuid */
  guid?: string
  baseType?: Type
  isSerializable?: boolean
  containsGenericParameters?: boolean
  isVisible?: boolean
  genericTypeParameters?: Type[] | null
  declaredConstructors?: ConstructorInfo[] | null
  declaredEvents?: EventInfo[] | null
  declaredFields?: FieldInfo[] | null
  declaredMembers?: MemberInfo[] | null
  declaredMethods?: MethodInfo[] | null
  declaredNestedTypes?: TypeInfo[] | null
  declaredProperties?: PropertyInfo[] | null
  implementedInterfaces?: Type[] | null
}

/** 添加 */
export interface UserAddInput {
  /**
   * 用户Id
   * @format int64
   */
  id?: number
  /**
   * 账号
   * @minLength 1
   */
  userName: string
  /**
   * 姓名
   * @minLength 1
   */
  name: string
  /** 手机号 */
  mobile?: string | null
  /** 邮箱 */
  email?: string | null
  /** 角色Ids */
  roleIds?: number[] | null
  /** 密码 */
  password?: string | null
  /** 启用 */
  enabled?: boolean
}

/** 修改密码 */
export interface UserChangePasswordInput {
  /**
   * 旧密码
   * @minLength 1
   */
  oldPassword: string
  /**
   * 新密码
   * @minLength 1
   */
  newPassword: string
  /**
   * 确认新密码
   * @minLength 1
   */
  confirmPassword: string
}

export interface UserGetBasicOutput {
  /** 头像 */
  avatar?: string | null
  /** 姓名 */
  name?: string | null
  /** 昵称 */
  nickName?: string | null
  /** 手机号 */
  mobile?: string | null
  /** 邮箱 */
  email?: string | null
}

export interface UserGetOrgDto {
  /** @format int64 */
  id?: number
  name?: string | null
}

export interface UserGetOutput {
  /**
   * 账号
   * @minLength 1
   */
  userName: string
  /**
   * 姓名
   * @minLength 1
   */
  name: string
  /** 手机号 */
  mobile?: string | null
  /** 邮箱 */
  email?: string | null
  /**
   * 主键Id
   * @format int64
   */
  id: number
  /** 角色列表 */
  roles?: UserGetRoleDto[] | null
  /** 部门列表 */
  orgs?: UserGetOrgDto[] | null
  /** 角色Ids */
  roleIds?: number[] | null
}

/** 用户分页查询条件 */
export type UserGetPageDto = object

export interface UserGetPageOutput {
  /**
   * 主键Id
   * @format int64
   */
  id?: number
  /** 账号 */
  userName?: string | null
  /** 姓名 */
  name?: string | null
  /** 手机号 */
  mobile?: string | null
  /** 邮箱 */
  email?: string | null
  /** DefaultUser=1,PlatformAdmin=100 */
  type?: UserType
  /** 角色 */
  roleNames?: string[] | null
  /** 是否主管 */
  isManager?: boolean
  /** 启用 */
  enabled?: boolean
  /**
   * 创建时间
   * @format date-time
   */
  createdTime?: string | null
}

export interface UserGetRoleDto {
  /** @format int64 */
  id?: number
  name?: string | null
}

export interface UserPermissionsOutput {
  httpMethods?: string | null
  path?: string | null
}

/** 重置密码 */
export interface UserResetPasswordInput {
  /** @format int64 */
  id?: number
  /** 密码 */
  password?: string | null
}

/**
 * DefaultUser=1,PlatformAdmin=100
 * @format int32
 */
export type UserType = 1 | 100

/** 更新基本信息 */
export interface UserUpdateBasicInput {
  /**
   * 姓名
   * @minLength 1
   */
  name: string
  /** 昵称 */
  nickName?: string | null
}

/** 修改 */
export interface UserUpdateInput {
  /**
   * 账号
   * @minLength 1
   */
  userName: string
  /**
   * 姓名
   * @minLength 1
   */
  name: string
  /** 手机号 */
  mobile?: string | null
  /** 邮箱 */
  email?: string | null
  /** 角色Ids */
  roleIds?: number[] | null
  /**
   * 主键Id
   * @format int64
   */
  id: number
}

export interface ValidateResult {
  /** Success=0,ValidateFail=1,Timeout=2 */
  result?: ValidateResultType
  message?: string | null
}

/**
 * Success=0,ValidateFail=1,Timeout=2
 * @format int32
 */
export type ValidateResultType = 0 | 1 | 2

/** 添加 */
export interface ViewAddInput {
  /**
   * 所属节点
   * @format int64
   */
  parentId?: number | null
  /** 视图命名 */
  name?: string | null
  /** 视图名称 */
  label?: string | null
  /** 视图路径 */
  path?: string | null
  /** 说明 */
  description?: string | null
  /** 缓存 */
  cache?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
}

export interface ViewEntity {
  /** @format int64 */
  id?: number
  /** @format int64 */
  createdUserId?: number | null
  /** @maxLength 50 */
  createdUserName?: string | null
  /** @format date-time */
  createdTime?: string | null
  /** @format int64 */
  modifiedUserId?: number | null
  /** @maxLength 50 */
  modifiedUserName?: string | null
  /** @format date-time */
  modifiedTime?: string | null
  isDeleted?: boolean
  /** @format int64 */
  parentId?: number
  name?: string | null
  label?: string | null
  path?: string | null
  description?: string | null
  cache?: boolean
  /** @format int32 */
  sort?: number
  enabled?: boolean
  childs?: ViewEntity[] | null
}

export interface ViewGetOutput {
  /**
   * 所属节点
   * @format int64
   */
  parentId?: number | null
  /** 视图命名 */
  name?: string | null
  /** 视图名称 */
  label?: string | null
  /** 视图路径 */
  path?: string | null
  /** 说明 */
  description?: string | null
  /** 缓存 */
  cache?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 视图Id
   * @format int64
   */
  id: number
}

export interface ViewListOutput {
  /**
   * 视图Id
   * @format int64
   */
  id?: number
  /**
   * 视图父级
   * @format int64
   */
  parentId?: number | null
  /** 视图命名 */
  name?: string | null
  /** 视图名称 */
  label?: string | null
  /** 视图路径 */
  path?: string | null
  /** 缓存 */
  cache?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /** 说明 */
  description?: string | null
}

export interface ViewSyncDto {
  /** 视图命名 */
  name?: string | null
  /** 地址 */
  path?: string | null
  /** 视图名称 */
  label?: string | null
  /** 说明 */
  description?: string | null
  /** 缓存 */
  cache?: boolean
}

export interface ViewSyncInput {
  views?: ViewSyncDto[] | null
}

/** 修改 */
export interface ViewUpdateInput {
  /**
   * 所属节点
   * @format int64
   */
  parentId?: number | null
  /** 视图命名 */
  name?: string | null
  /** 视图名称 */
  label?: string | null
  /** 视图路径 */
  path?: string | null
  /** 说明 */
  description?: string | null
  /** 缓存 */
  cache?: boolean
  /**
   * 排序
   * @format int32
   */
  sort?: number
  /** 启用 */
  enabled?: boolean
  /**
   * 视图Id
   * @format int64
   */
  id: number
}

export interface WaitHandle {
  handle?: IntPtr
  safeWaitHandle?: SafeWaitHandle
}

export interface WebSocketManager {
  isWebSocketRequest?: boolean
  webSocketRequestedProtocols?: string[] | null
}

export interface X500DistinguishedName {
  oid?: Oid
  /** @format byte */
  rawData?: string | null
  name?: string | null
}

export interface X509Certificate2 {
  handle?: IntPtr
  issuer?: string | null
  subject?: string | null
  archived?: boolean
  extensions?: X509Extension[] | null
  friendlyName?: string | null
  hasPrivateKey?: boolean
  privateKey?: AsymmetricAlgorithm
  issuerName?: X500DistinguishedName
  /** @format date-time */
  notAfter?: string
  /** @format date-time */
  notBefore?: string
  publicKey?: PublicKey
  /** @format byte */
  rawData?: string | null
  serialNumber?: string | null
  signatureAlgorithm?: Oid
  subjectName?: X500DistinguishedName
  thumbprint?: string | null
  /** @format int32 */
  version?: number
}

export interface X509Extension {
  oid?: Oid
  /** @format byte */
  rawData?: string | null
  critical?: boolean
}
