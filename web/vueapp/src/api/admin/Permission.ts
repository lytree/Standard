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

import { AxiosResponse } from 'axios'
import {
  AddressFamily,
  Claim,
  ClaimsIdentity,
  HttpContext,
  IResponseCookies,
  IServiceProvider,
  IntPtr,
  KeySizes,
  KeyValuePairStringString,
  KeyValuePairStringStringValues,
  KeyValuePairTypeObject,
  PathString,
  PermissionAddApiInput,
  PermissionAddDotInput,
  PermissionAddGroupInput,
  PermissionAddMenuInput,
  PermissionAssignInput,
  PermissionUpdateApiInput,
  PermissionUpdateDotInput,
  PermissionUpdateGroupInput,
  PermissionUpdateMenuInput,
  PipeReader,
  ResultOutputIEnumerableObject,
  ResultOutputInt64,
  ResultOutputListInt64,
  ResultOutputListPermissionListOutput,
  ResultOutputPermissionGetApiOutput,
  ResultOutputPermissionGetDotOutput,
  ResultOutputPermissionGetGroupOutput,
  ResultOutputPermissionGetMenuOutput,
  ResultOutputString,
  X509Extension,
} from './data-contracts'
import { ContentType, HttpClient, HttpResponse, RequestParams } from './http-client'

export class PermissionApi<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags permission
   * @name GetGroup
   * @summary 查询分组
   * @request GET:/api/admin/permission/get-group
   * @secure
   */
  getGroup = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputPermissionGetGroupOutput, any>({
      path: `/api/admin/permission/get-group`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetMenu
   * @summary 查询菜单
   * @request GET:/api/admin/permission/get-menu
   * @secure
   */
  getMenu = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputPermissionGetMenuOutput, any>({
      path: `/api/admin/permission/get-menu`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetApi
   * @summary 查询接口
   * @request GET:/api/admin/permission/get-api
   * @secure
   */
  getApi = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputPermissionGetApiOutput, any>({
      path: `/api/admin/permission/get-api`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetDot
   * @summary 查询权限点
   * @request GET:/api/admin/permission/get-dot
   * @secure
   */
  getDot = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputPermissionGetDotOutput, any>({
      path: `/api/admin/permission/get-dot`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetList
   * @summary 查询权限列表
   * @request GET:/api/admin/permission/get-list
   * @secure
   */
  getList = (
    query?: {
      key?: string
      /** @format date-time */
      start?: string
      /** @format date-time */
      end?: string
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputListPermissionListOutput, any>({
      path: `/api/admin/permission/get-list`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetPermissionList
   * @summary 查询授权权限列表
   * @request GET:/api/admin/permission/get-permission-list
   * @secure
   */
  getPermissionList = (params: RequestParams = {}) =>
    this.request<ResultOutputIEnumerableObject, any>({
      path: `/api/admin/permission/get-permission-list`,
      method: 'GET',
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetRolePermissionList
   * @summary 查询角色权限列表
   * @request GET:/api/admin/permission/get-role-permission-list
   * @secure
   */
  getRolePermissionList = (
    query?: {
      /**
       * @format int64
       * @default 0
       */
      roleId?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputListInt64, any>({
      path: `/api/admin/permission/get-role-permission-list`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name AddGroup
   * @summary 新增分组
   * @request POST:/api/admin/permission/add-group
   * @secure
   */
  addGroup = (data: PermissionAddGroupInput, params: RequestParams = {}) =>
    this.request<ResultOutputInt64, any>({
      path: `/api/admin/permission/add-group`,
      method: 'POST',
      body: data,
      secure: true,
      type: ContentType.Json,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name AddMenu
   * @summary 新增菜单
   * @request POST:/api/admin/permission/add-menu
   * @secure
   */
  addMenu = (data: PermissionAddMenuInput, params: RequestParams = {}) =>
    this.request<ResultOutputInt64, any>({
      path: `/api/admin/permission/add-menu`,
      method: 'POST',
      body: data,
      secure: true,
      type: ContentType.Json,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name AddApi
   * @summary 新增接口
   * @request POST:/api/admin/permission/add-api
   * @secure
   */
  addApi = (data: PermissionAddApiInput, params: RequestParams = {}) =>
    this.request<ResultOutputInt64, any>({
      path: `/api/admin/permission/add-api`,
      method: 'POST',
      body: data,
      secure: true,
      type: ContentType.Json,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name AddDot
   * @summary 新增权限点
   * @request POST:/api/admin/permission/add-dot
   * @secure
   */
  addDot = (data: PermissionAddDotInput, params: RequestParams = {}) =>
    this.request<ResultOutputInt64, any>({
      path: `/api/admin/permission/add-dot`,
      method: 'POST',
      body: data,
      secure: true,
      type: ContentType.Json,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name UpdateGroup
   * @summary 修改分组
   * @request PUT:/api/admin/permission/update-group
   * @secure
   */
  updateGroup = (data: PermissionUpdateGroupInput, params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/update-group`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name UpdateMenu
   * @summary 修改菜单
   * @request PUT:/api/admin/permission/update-menu
   * @secure
   */
  updateMenu = (data: PermissionUpdateMenuInput, params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/update-menu`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name UpdateApi
   * @summary 修改接口
   * @request PUT:/api/admin/permission/update-api
   * @secure
   */
  updateApi = (data: PermissionUpdateApiInput, params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/update-api`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name UpdateDot
   * @summary 修改权限点
   * @request PUT:/api/admin/permission/update-dot
   * @secure
   */
  updateDot = (data: PermissionUpdateDotInput, params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/update-dot`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name Delete
   * @summary 彻底删除
   * @request DELETE:/api/admin/permission/delete
   * @secure
   */
  delete = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/delete`,
      method: 'DELETE',
      query: query,
      secure: true,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name SoftDelete
   * @summary 删除
   * @request DELETE:/api/admin/permission/soft-delete
   * @secure
   */
  softDelete = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/soft-delete`,
      method: 'DELETE',
      query: query,
      secure: true,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name Assign
   * @summary 保存角色权限
   * @request POST:/api/admin/permission/assign
   * @secure
   */
  assign = (data: PermissionAssignInput, params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/permission/assign`,
      method: 'POST',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags permission
   * @name GetIp
   * @summary 获得IP地址
   * @request GET:/api/admin/permission/get-ip
   * @secure
   */
  getIp = (
    data: {
      'HttpContext.Request.Form'?: KeyValuePairStringStringValues[]
      'HttpContext.Response.HttpContext.Request.Form'?: KeyValuePairStringStringValues[]
      Form?: KeyValuePairStringStringValues[]
    },
    query?: {
      httpContextFeatures?: KeyValuePairTypeObject[]
      httpContextRequestHttpContext?: HttpContext
      httpContextRequestMethod?: string
      httpContextRequestScheme?: string
      httpContextRequestIsHttps?: boolean
      httpContextRequestHostValue?: string
      httpContextRequestHostHasValue?: boolean
      httpContextRequestHostHost?: string
      /** @format int32 */
      httpContextRequestHostPort?: number
      httpContextRequestPathBase?: PathString
      httpContextRequestPath?: PathString
      httpContextRequestQueryStringValue?: string
      httpContextRequestQueryStringHasValue?: boolean
      httpContextRequestQuery?: KeyValuePairStringStringValues[]
      httpContextRequestProtocol?: string
      httpContextRequestHeaders?: Record<string, string[]>
      httpContextRequestCookies?: KeyValuePairStringString[]
      /** @format int64 */
      httpContextRequestContentLength?: number
      httpContextRequestContentType?: string
      httpContextRequestBodyCanRead?: boolean
      httpContextRequestBodyCanWrite?: boolean
      httpContextRequestBodyCanSeek?: boolean
      httpContextRequestBodyCanTimeout?: boolean
      /** @format int64 */
      httpContextRequestBodyLength?: number
      /** @format int64 */
      httpContextRequestBodyPosition?: number
      /** @format int32 */
      httpContextRequestBodyReadTimeout?: number
      /** @format int32 */
      httpContextRequestBodyWriteTimeout?: number
      httpContextRequestBodyReader?: PipeReader
      httpContextRequestHasFormContentType?: boolean
      httpContextRequestRouteValues?: Record<string, any>
      httpContextResponseHttpContextFeatures?: KeyValuePairTypeObject[]
      httpContextResponseHttpContextRequestHttpContext?: HttpContext
      httpContextResponseHttpContextRequestMethod?: string
      httpContextResponseHttpContextRequestScheme?: string
      httpContextResponseHttpContextRequestIsHttps?: boolean
      httpContextResponseHttpContextRequestHostValue?: string
      httpContextResponseHttpContextRequestHostHasValue?: boolean
      httpContextResponseHttpContextRequestHostHost?: string
      /** @format int32 */
      httpContextResponseHttpContextRequestHostPort?: number
      httpContextResponseHttpContextRequestPathBase?: PathString
      httpContextResponseHttpContextRequestPath?: PathString
      httpContextResponseHttpContextRequestQueryStringValue?: string
      httpContextResponseHttpContextRequestQueryStringHasValue?: boolean
      httpContextResponseHttpContextRequestQuery?: KeyValuePairStringStringValues[]
      httpContextResponseHttpContextRequestProtocol?: string
      httpContextResponseHttpContextRequestHeaders?: Record<string, string[]>
      httpContextResponseHttpContextRequestCookies?: KeyValuePairStringString[]
      /** @format int64 */
      httpContextResponseHttpContextRequestContentLength?: number
      httpContextResponseHttpContextRequestContentType?: string
      httpContextResponseHttpContextRequestBodyCanRead?: boolean
      httpContextResponseHttpContextRequestBodyCanWrite?: boolean
      httpContextResponseHttpContextRequestBodyCanSeek?: boolean
      httpContextResponseHttpContextRequestBodyCanTimeout?: boolean
      /** @format int64 */
      httpContextResponseHttpContextRequestBodyLength?: number
      /** @format int64 */
      httpContextResponseHttpContextRequestBodyPosition?: number
      /** @format int32 */
      httpContextResponseHttpContextRequestBodyReadTimeout?: number
      /** @format int32 */
      httpContextResponseHttpContextRequestBodyWriteTimeout?: number
      httpContextResponseHttpContextRequestBodyReader?: PipeReader
      httpContextResponseHttpContextRequestHasFormContentType?: boolean
      httpContextResponseHttpContextRequestRouteValues?: Record<string, any>
      httpContextResponseHttpContextResponse?: HttpResponse
      httpContextResponseHttpContextConnectionId?: string
      /** Unspecified=0,Unix=1,InterNetwork=2,ImpLink=3,Pup=4,Chaos=5,Ipx=6,Ipx=6,Iso=7,Iso=7,Ecma=8,DataKit=9,Ccitt=10,Sna=11,DecNet=12,DataLink=13,Lat=14,HyperChannel=15,AppleTalk=16,NetBios=17,VoiceView=18,FireFox=19,Banyan=21,Atm=22,InterNetworkV6=23,Cluster=24,Ieee12844=25,Irda=26,NetworkDesigners=28,Max=29,Packet=65536,ControllerAreaNetwork=65537,Unknown=-1 */
      httpContextResponseHttpContextConnectionRemoteIpAddressAddressFamily?: AddressFamily
      /** @format int64 */
      httpContextResponseHttpContextConnectionRemoteIpAddressScopeId?: number
      httpContextResponseHttpContextConnectionRemoteIpAddressIsIPv6Multicast?: boolean
      httpContextResponseHttpContextConnectionRemoteIpAddressIsIPv6LinkLocal?: boolean
      httpContextResponseHttpContextConnectionRemoteIpAddressIsIPv6SiteLocal?: boolean
      httpContextResponseHttpContextConnectionRemoteIpAddressIsIPv6Teredo?: boolean
      httpContextResponseHttpContextConnectionRemoteIpAddressIsIPv6UniqueLocal?: boolean
      httpContextResponseHttpContextConnectionRemoteIpAddressIsIPv4MappedToIPv6?: boolean
      /**
       * @deprecated
       * @format int64
       */
      httpContextResponseHttpContextConnectionRemoteIpAddressAddress?: number
      /** @format int32 */
      httpContextResponseHttpContextConnectionRemotePort?: number
      /** Unspecified=0,Unix=1,InterNetwork=2,ImpLink=3,Pup=4,Chaos=5,Ipx=6,Ipx=6,Iso=7,Iso=7,Ecma=8,DataKit=9,Ccitt=10,Sna=11,DecNet=12,DataLink=13,Lat=14,HyperChannel=15,AppleTalk=16,NetBios=17,VoiceView=18,FireFox=19,Banyan=21,Atm=22,InterNetworkV6=23,Cluster=24,Ieee12844=25,Irda=26,NetworkDesigners=28,Max=29,Packet=65536,ControllerAreaNetwork=65537,Unknown=-1 */
      httpContextResponseHttpContextConnectionLocalIpAddressAddressFamily?: AddressFamily
      /** @format int64 */
      httpContextResponseHttpContextConnectionLocalIpAddressScopeId?: number
      httpContextResponseHttpContextConnectionLocalIpAddressIsIPv6Multicast?: boolean
      httpContextResponseHttpContextConnectionLocalIpAddressIsIPv6LinkLocal?: boolean
      httpContextResponseHttpContextConnectionLocalIpAddressIsIPv6SiteLocal?: boolean
      httpContextResponseHttpContextConnectionLocalIpAddressIsIPv6Teredo?: boolean
      httpContextResponseHttpContextConnectionLocalIpAddressIsIPv6UniqueLocal?: boolean
      httpContextResponseHttpContextConnectionLocalIpAddressIsIPv4MappedToIPv6?: boolean
      /**
       * @deprecated
       * @format int64
       */
      httpContextResponseHttpContextConnectionLocalIpAddressAddress?: number
      /** @format int32 */
      httpContextResponseHttpContextConnectionLocalPort?: number
      httpContextResponseHttpContextConnectionClientCertificateArchived?: boolean
      httpContextResponseHttpContextConnectionClientCertificateExtensions?: X509Extension[]
      httpContextResponseHttpContextConnectionClientCertificateFriendlyName?: string
      httpContextResponseHttpContextConnectionClientCertificateHasPrivateKey?: boolean
      /** @format int32 */
      httpContextResponseHttpContextConnectionClientCertificatePrivateKeyKeySize?: number
      httpContextResponseHttpContextConnectionClientCertificatePrivateKeyLegalKeySizes?: KeySizes[]
      httpContextResponseHttpContextConnectionClientCertificatePrivateKeySignatureAlgorithm?: string
      httpContextResponseHttpContextConnectionClientCertificatePrivateKeyKeyExchangeAlgorithm?: string
      httpContextResponseHttpContextConnectionClientCertificateIssuerNameName?: string
      httpContextResponseHttpContextConnectionClientCertificateIssuerNameOidValue?: string
      httpContextResponseHttpContextConnectionClientCertificateIssuerNameOidFriendlyName?: string
      /** @format byte */
      httpContextResponseHttpContextConnectionClientCertificateIssuerNameRawData?: string
      /** @format date-time */
      httpContextResponseHttpContextConnectionClientCertificateNotAfter?: string
      /** @format date-time */
      httpContextResponseHttpContextConnectionClientCertificateNotBefore?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyEncodedKeyValueOidValue?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyEncodedKeyValueOidFriendlyName?: string
      /** @format byte */
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyEncodedKeyValueRawData?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyEncodedParametersOidValue?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyEncodedParametersOidFriendlyName?: string
      /** @format byte */
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyEncodedParametersRawData?: string
      /** @format int32 */
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyKeyKeySize?: number
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyKeyLegalKeySizes?: KeySizes[]
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyKeySignatureAlgorithm?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyKeyKeyExchangeAlgorithm?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyOidValue?: string
      httpContextResponseHttpContextConnectionClientCertificatePublicKeyOidFriendlyName?: string
      /** @format byte */
      httpContextResponseHttpContextConnectionClientCertificateRawData?: string
      httpContextResponseHttpContextConnectionClientCertificateSerialNumber?: string
      httpContextResponseHttpContextConnectionClientCertificateSignatureAlgorithmValue?: string
      httpContextResponseHttpContextConnectionClientCertificateSignatureAlgorithmFriendlyName?: string
      httpContextResponseHttpContextConnectionClientCertificateSubjectNameName?: string
      httpContextResponseHttpContextConnectionClientCertificateSubjectNameOidValue?: string
      httpContextResponseHttpContextConnectionClientCertificateSubjectNameOidFriendlyName?: string
      /** @format byte */
      httpContextResponseHttpContextConnectionClientCertificateSubjectNameRawData?: string
      httpContextResponseHttpContextConnectionClientCertificateThumbprint?: string
      /** @format int32 */
      httpContextResponseHttpContextConnectionClientCertificateVersion?: number
      httpContextResponseHttpContextConnectionClientCertificateHandle?: IntPtr
      httpContextResponseHttpContextConnectionClientCertificateIssuer?: string
      httpContextResponseHttpContextConnectionClientCertificateSubject?: string
      httpContextResponseHttpContextWebSocketsIsWebSocketRequest?: boolean
      httpContextResponseHttpContextWebSocketsWebSocketRequestedProtocols?: string[]
      httpContextResponseHttpContextUserClaims?: Claim[]
      httpContextResponseHttpContextUserIdentities?: ClaimsIdentity[]
      httpContextResponseHttpContextUserIdentityName?: string
      httpContextResponseHttpContextUserIdentityAuthenticationType?: string
      httpContextResponseHttpContextUserIdentityIsAuthenticated?: boolean
      httpContextResponseHttpContextItems?: Record<string, any>
      httpContextResponseHttpContextRequestServices?: IServiceProvider
      httpContextResponseHttpContextTraceIdentifier?: string
      httpContextResponseHttpContextSessionIsAvailable?: boolean
      httpContextResponseHttpContextSessionId?: string
      httpContextResponseHttpContextSessionKeys?: string[]
      /** @format int32 */
      httpContextResponseStatusCode?: number
      httpContextResponseHeaders?: Record<string, string[]>
      httpContextResponseBodyCanRead?: boolean
      httpContextResponseBodyCanWrite?: boolean
      httpContextResponseBodyCanSeek?: boolean
      httpContextResponseBodyCanTimeout?: boolean
      /** @format int64 */
      httpContextResponseBodyLength?: number
      /** @format int64 */
      httpContextResponseBodyPosition?: number
      /** @format int32 */
      httpContextResponseBodyReadTimeout?: number
      /** @format int32 */
      httpContextResponseBodyWriteTimeout?: number
      httpContextResponseBodyWriterCanGetUnflushedBytes?: boolean
      /** @format int64 */
      httpContextResponseBodyWriterUnflushedBytes?: number
      /** @format int64 */
      httpContextResponseContentLength?: number
      httpContextResponseContentType?: string
      httpContextResponseCookies?: IResponseCookies
      httpContextResponseHasStarted?: boolean
      httpContextConnectionId?: string
      /** Unspecified=0,Unix=1,InterNetwork=2,ImpLink=3,Pup=4,Chaos=5,Ipx=6,Ipx=6,Iso=7,Iso=7,Ecma=8,DataKit=9,Ccitt=10,Sna=11,DecNet=12,DataLink=13,Lat=14,HyperChannel=15,AppleTalk=16,NetBios=17,VoiceView=18,FireFox=19,Banyan=21,Atm=22,InterNetworkV6=23,Cluster=24,Ieee12844=25,Irda=26,NetworkDesigners=28,Max=29,Packet=65536,ControllerAreaNetwork=65537,Unknown=-1 */
      httpContextConnectionRemoteIpAddressAddressFamily?: AddressFamily
      /** @format int64 */
      httpContextConnectionRemoteIpAddressScopeId?: number
      httpContextConnectionRemoteIpAddressIsIPv6Multicast?: boolean
      httpContextConnectionRemoteIpAddressIsIPv6LinkLocal?: boolean
      httpContextConnectionRemoteIpAddressIsIPv6SiteLocal?: boolean
      httpContextConnectionRemoteIpAddressIsIPv6Teredo?: boolean
      httpContextConnectionRemoteIpAddressIsIPv6UniqueLocal?: boolean
      httpContextConnectionRemoteIpAddressIsIPv4MappedToIPv6?: boolean
      /**
       * @deprecated
       * @format int64
       */
      httpContextConnectionRemoteIpAddressAddress?: number
      /** @format int32 */
      httpContextConnectionRemotePort?: number
      /** Unspecified=0,Unix=1,InterNetwork=2,ImpLink=3,Pup=4,Chaos=5,Ipx=6,Ipx=6,Iso=7,Iso=7,Ecma=8,DataKit=9,Ccitt=10,Sna=11,DecNet=12,DataLink=13,Lat=14,HyperChannel=15,AppleTalk=16,NetBios=17,VoiceView=18,FireFox=19,Banyan=21,Atm=22,InterNetworkV6=23,Cluster=24,Ieee12844=25,Irda=26,NetworkDesigners=28,Max=29,Packet=65536,ControllerAreaNetwork=65537,Unknown=-1 */
      httpContextConnectionLocalIpAddressAddressFamily?: AddressFamily
      /** @format int64 */
      httpContextConnectionLocalIpAddressScopeId?: number
      httpContextConnectionLocalIpAddressIsIPv6Multicast?: boolean
      httpContextConnectionLocalIpAddressIsIPv6LinkLocal?: boolean
      httpContextConnectionLocalIpAddressIsIPv6SiteLocal?: boolean
      httpContextConnectionLocalIpAddressIsIPv6Teredo?: boolean
      httpContextConnectionLocalIpAddressIsIPv6UniqueLocal?: boolean
      httpContextConnectionLocalIpAddressIsIPv4MappedToIPv6?: boolean
      /**
       * @deprecated
       * @format int64
       */
      httpContextConnectionLocalIpAddressAddress?: number
      /** @format int32 */
      httpContextConnectionLocalPort?: number
      httpContextConnectionClientCertificateArchived?: boolean
      httpContextConnectionClientCertificateExtensions?: X509Extension[]
      httpContextConnectionClientCertificateFriendlyName?: string
      httpContextConnectionClientCertificateHasPrivateKey?: boolean
      /** @format int32 */
      httpContextConnectionClientCertificatePrivateKeyKeySize?: number
      httpContextConnectionClientCertificatePrivateKeyLegalKeySizes?: KeySizes[]
      httpContextConnectionClientCertificatePrivateKeySignatureAlgorithm?: string
      httpContextConnectionClientCertificatePrivateKeyKeyExchangeAlgorithm?: string
      httpContextConnectionClientCertificateIssuerNameName?: string
      httpContextConnectionClientCertificateIssuerNameOidValue?: string
      httpContextConnectionClientCertificateIssuerNameOidFriendlyName?: string
      /** @format byte */
      httpContextConnectionClientCertificateIssuerNameRawData?: string
      /** @format date-time */
      httpContextConnectionClientCertificateNotAfter?: string
      /** @format date-time */
      httpContextConnectionClientCertificateNotBefore?: string
      httpContextConnectionClientCertificatePublicKeyEncodedKeyValueOidValue?: string
      httpContextConnectionClientCertificatePublicKeyEncodedKeyValueOidFriendlyName?: string
      /** @format byte */
      httpContextConnectionClientCertificatePublicKeyEncodedKeyValueRawData?: string
      httpContextConnectionClientCertificatePublicKeyEncodedParametersOidValue?: string
      httpContextConnectionClientCertificatePublicKeyEncodedParametersOidFriendlyName?: string
      /** @format byte */
      httpContextConnectionClientCertificatePublicKeyEncodedParametersRawData?: string
      /** @format int32 */
      httpContextConnectionClientCertificatePublicKeyKeyKeySize?: number
      httpContextConnectionClientCertificatePublicKeyKeyLegalKeySizes?: KeySizes[]
      httpContextConnectionClientCertificatePublicKeyKeySignatureAlgorithm?: string
      httpContextConnectionClientCertificatePublicKeyKeyKeyExchangeAlgorithm?: string
      httpContextConnectionClientCertificatePublicKeyOidValue?: string
      httpContextConnectionClientCertificatePublicKeyOidFriendlyName?: string
      /** @format byte */
      httpContextConnectionClientCertificateRawData?: string
      httpContextConnectionClientCertificateSerialNumber?: string
      httpContextConnectionClientCertificateSignatureAlgorithmValue?: string
      httpContextConnectionClientCertificateSignatureAlgorithmFriendlyName?: string
      httpContextConnectionClientCertificateSubjectNameName?: string
      httpContextConnectionClientCertificateSubjectNameOidValue?: string
      httpContextConnectionClientCertificateSubjectNameOidFriendlyName?: string
      /** @format byte */
      httpContextConnectionClientCertificateSubjectNameRawData?: string
      httpContextConnectionClientCertificateThumbprint?: string
      /** @format int32 */
      httpContextConnectionClientCertificateVersion?: number
      httpContextConnectionClientCertificateHandle?: IntPtr
      httpContextConnectionClientCertificateIssuer?: string
      httpContextConnectionClientCertificateSubject?: string
      httpContextWebSocketsIsWebSocketRequest?: boolean
      httpContextWebSocketsWebSocketRequestedProtocols?: string[]
      httpContextUserClaims?: Claim[]
      httpContextUserIdentities?: ClaimsIdentity[]
      httpContextUserIdentityName?: string
      httpContextUserIdentityAuthenticationType?: string
      httpContextUserIdentityIsAuthenticated?: boolean
      httpContextItems?: Record<string, any>
      httpContextRequestServices?: IServiceProvider
      httpContextTraceIdentifier?: string
      httpContextSessionIsAvailable?: boolean
      httpContextSessionId?: string
      httpContextSessionKeys?: string[]
      Method?: string
      Scheme?: string
      IsHttps?: boolean
      hostValue?: string
      hostHasValue?: boolean
      hostHost?: string
      /** @format int32 */
      hostPort?: number
      PathBase?: PathString
      Path?: PathString
      queryStringValue?: string
      queryStringHasValue?: boolean
      Query?: KeyValuePairStringStringValues[]
      Protocol?: string
      Headers?: Record<string, string[]>
      Cookies?: KeyValuePairStringString[]
      /** @format int64 */
      ContentLength?: number
      ContentType?: string
      bodyCanRead?: boolean
      bodyCanWrite?: boolean
      bodyCanSeek?: boolean
      bodyCanTimeout?: boolean
      /** @format int64 */
      bodyLength?: number
      /** @format int64 */
      bodyPosition?: number
      /** @format int32 */
      bodyReadTimeout?: number
      /** @format int32 */
      bodyWriteTimeout?: number
      BodyReader?: PipeReader
      HasFormContentType?: boolean
      RouteValues?: Record<string, any>
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputString, any>({
      path: `/api/admin/permission/get-ip`,
      method: 'GET',
      query: query,
      body: data,
      secure: true,
      type: ContentType.FormData,
      format: 'json',
      ...params,
    })
}
