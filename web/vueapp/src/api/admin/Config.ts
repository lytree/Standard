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
  ConfigAddInput,
  ConfigUpdateInput,
  HttpContext,
  IResponseCookies,
  IServiceProvider,
  IntPtr,
  KeySizes,
  KeyValuePairStringString,
  KeyValuePairStringStringValues,
  KeyValuePairTypeObject,
  PageInputConfigGetPageDto,
  PathString,
  PipeReader,
  ResultOutputConfigGetOutput,
  ResultOutputInt64,
  ResultOutputPageOutputConfigGetPageOutput,
  ResultOutputString,
  X509Extension,
} from './data-contracts'
import { ContentType, HttpClient, HttpResponse, RequestParams } from './http-client'

export class ConfigApi<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags config
   * @name Get
   * @summary 查询
   * @request GET:/api/admin/config/get
   * @secure
   */
  get = (
    query?: {
      /** @format int64 */
      id?: number
    },
    params: RequestParams = {}
  ) =>
    this.request<ResultOutputConfigGetOutput, any>({
      path: `/api/admin/config/get`,
      method: 'GET',
      query: query,
      secure: true,
      format: 'json',
      ...params,
    })
  /**
   * No description
   *
   * @tags config
   * @name GetPage
   * @summary 查询分页
   * @request POST:/api/admin/config/get-page
   * @secure
   */
  getPage = (data: PageInputConfigGetPageDto, params: RequestParams = {}) =>
    this.request<ResultOutputPageOutputConfigGetPageOutput, any>({
      path: `/api/admin/config/get-page`,
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
   * @tags config
   * @name Add
   * @summary 新增
   * @request POST:/api/admin/config/add
   * @secure
   */
  add = (data: ConfigAddInput, params: RequestParams = {}) =>
    this.request<ResultOutputInt64, any>({
      path: `/api/admin/config/add`,
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
   * @tags config
   * @name Update
   * @summary 修改
   * @request PUT:/api/admin/config/update
   * @secure
   */
  update = (data: ConfigUpdateInput, params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/config/update`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags config
   * @name Delete
   * @summary 彻底删除
   * @request DELETE:/api/admin/config/delete
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
      path: `/api/admin/config/delete`,
      method: 'DELETE',
      query: query,
      secure: true,
      ...params,
    })
  /**
   * No description
   *
   * @tags config
   * @name BatchDelete
   * @summary 批量彻底删除
   * @request PUT:/api/admin/config/batch-delete
   * @secure
   */
  batchDelete = (data: number[], params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/config/batch-delete`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags config
   * @name SoftDelete
   * @summary 删除
   * @request DELETE:/api/admin/config/soft-delete
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
      path: `/api/admin/config/soft-delete`,
      method: 'DELETE',
      query: query,
      secure: true,
      ...params,
    })
  /**
   * No description
   *
   * @tags config
   * @name BatchSoftDelete
   * @summary 批量删除
   * @request PUT:/api/admin/config/batch-soft-delete
   * @secure
   */
  batchSoftDelete = (data: number[], params: RequestParams = {}) =>
    this.request<AxiosResponse, any>({
      path: `/api/admin/config/batch-soft-delete`,
      method: 'PUT',
      body: data,
      secure: true,
      type: ContentType.Json,
      ...params,
    })
  /**
   * No description
   *
   * @tags config
   * @name GetIp
   * @summary 获得IP地址
   * @request GET:/api/admin/config/get-ip
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
      path: `/api/admin/config/get-ip`,
      method: 'GET',
      query: query,
      body: data,
      secure: true,
      type: ContentType.FormData,
      format: 'json',
      ...params,
    })
}
