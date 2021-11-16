using System.Text.Json.Serialization;

namespace Aria2Net
{
    public class Aria2Options
    {
        [JsonPropertyName("allow-overwrite")]
        public bool AllowOverwrite { get; set; }

        [JsonPropertyName("allow-piece-length-change")]
        public bool AllowPieceLengthChange { get; set; }

        [JsonPropertyName("always-resume")]
        public bool AlwaysResume { get; set; }

        [JsonPropertyName("async-dns")]
        public bool AsyncDns { get; set; }

        [JsonPropertyName("auto-file-renaming")]
        public bool AutoFileRenaming { get; set; }

        [JsonPropertyName("auto-save-interval")]
        public int AutoSaveInterval { get; set; }

        [JsonPropertyName("bt-detach-seed-only")]
        public bool BtDetachSeedOnly { get; set; }

        [JsonPropertyName("bt-enable-hook-after-hash-check")]
        public bool BtEnableHookAfterHashCheck { get; set; }

        [JsonPropertyName("bt-enable-lpd")]
        public bool BtEnableLpd { get; set; }

        [JsonPropertyName("bt-force-encryption")]
        public bool BtForceEncryption { get; set; }

        [JsonPropertyName("bt-hash-check-seed")]
        public bool BtHashCheckSeed { get; set; }

        [JsonPropertyName("bt-load-saved-metadata")]
        public bool BtLoadSavedMetadata { get; set; }

        [JsonPropertyName("bt-max-open-files")]
        public int BtMaxOpenFiles { get; set; }

        [JsonPropertyName("bt-max-peers")]
        public int BtMaxPeers { get; set; }

        [JsonPropertyName("bt-metadata-only")]
        public bool BtMetadataOnly { get; set; }

        [JsonPropertyName("bt-min-crypto-level")]
        public string BtMinCryptoLevel { get; set; }

        [JsonPropertyName("bt-remove-unselected-file")]
        public bool BtRemoveUnselectedFile { get; set; }

        [JsonPropertyName("bt-request-peer-speed-limit")]
        public int BtRequestPeerSpeedLimit { get; set; }

        [JsonPropertyName("bt-require-crypto")]
        public bool BtRequireCrypto { get; set; }

        [JsonPropertyName("bt-save-metadata")]
        public bool BtSaveMetadata { get; set; }

        [JsonPropertyName("bt-seed-unverified")]
        public bool BtSeedUnverified { get; set; }

        [JsonPropertyName("bt-stop-timeout")]
        public int BtStopTimeout { get; set; }

        [JsonPropertyName("bt-tracker-connect-timeout")]
        public int BtTrackerConnectTimeout { get; set; }

        [JsonPropertyName("bt-tracker-interval")]
        public int BtTrackerInterval { get; set; }

        [JsonPropertyName("bt-tracker-timeout")]
        public int BtTrackerTimeout { get; set; }

        [JsonPropertyName("check-certificate")]
        public bool CheckCertificate { get; set; }

        [JsonPropertyName("check-integrity")]
        public bool CheckIntegrity { get; set; }

        [JsonPropertyName("conditional-get")]
        public bool ConditionalGet { get; set; }

        [JsonPropertyName("conf-path")]
        public string ConfPath { get; set; }

        [JsonPropertyName("connect-timeout")]
        public int ConnectTimeout { get; set; }

        [JsonPropertyName("console-log-level")]
        public string ConsoleLogLevel { get; set; }

        [JsonPropertyName("content-disposition-default-utf8")]
        public bool ContentDispositionDefaultUtf8 { get; set; }

        [JsonPropertyName("continue")]
        public bool Continue { get; set; }

        [JsonPropertyName("daemon")]
        public bool Daemon { get; set; }

        [JsonPropertyName("deferred-input")]
        public bool DeferredInput { get; set; }

        [JsonPropertyName("dht-file-path")]
        public string DhtFilePath { get; set; }

        [JsonPropertyName("dht-file-path6")]
        public string DhtFilePath6 { get; set; }

        [JsonPropertyName("dht-listen-port")]
        public string DhtListenPort { get; set; }

        [JsonPropertyName("dht-message-timeout")]
        public int DhtMessageTimeout { get; set; }

        [JsonPropertyName("dir")]
        public string Dir { get; set; }

        [JsonPropertyName("disable-ipv6")]
        public bool DisableIpv6 { get; set; }

        [JsonPropertyName("disk-cache")]
        public int DiskCache { get; set; }

        [JsonPropertyName("download-result")]
        public string DownloadResult { get; set; }

        [JsonPropertyName("dry-run")]
        public bool DryRun { get; set; }

        [JsonPropertyName("dscp")]
        public int Dscp { get; set; }

        [JsonPropertyName("enable-color")]
        public bool EnableColor { get; set; }

        [JsonPropertyName("enable-dht")]
        public bool EnableDht { get; set; }

        [JsonPropertyName("enable-dht6")]
        public bool EnableDht6 { get; set; }

        [JsonPropertyName("enable-http-keep-alive")]
        public bool EnableHttpKeepAlive { get; set; }

        [JsonPropertyName("enable-http-pipelining")]
        public bool EnableHttpPipelining { get; set; }

        [JsonPropertyName("enable-mmap")]
        public bool EnableMmap { get; set; }

        [JsonPropertyName("enable-peer-exchange")]
        public bool EnablePeerExchange { get; set; }

        [JsonPropertyName("enable-rpc")]
        public bool EnableRpc { get; set; }

        [JsonPropertyName("event-poll")]
        public string EventPoll { get; set; }

        [JsonPropertyName("file-allocation")]
        public string FileAllocation { get; set; }

        [JsonPropertyName("follow-metalink")]
        public bool FollowMetalink { get; set; }

        [JsonPropertyName("follow-torrent")]
        public bool FollowTorrent { get; set; }

        [JsonPropertyName("force-save")]
        public bool ForceSave { get; set; }

        [JsonPropertyName("ftp-pasv")]
        public bool FtpPasv { get; set; }

        [JsonPropertyName("ftp-reuse-connection")]
        public bool FtpReuseConnection { get; set; }

        [JsonPropertyName("ftp-type")]
        public string FtpType { get; set; }

        [JsonPropertyName("hash-check-only")]
        public bool HashCheckOnly { get; set; }

        [JsonPropertyName("help")]
        public string Help { get; set; }

        [JsonPropertyName("http-accept-gzip")]
        public bool HttpAcceptGzip { get; set; }

        [JsonPropertyName("http-auth-challenge")]
        public bool HttpAuthChallenge { get; set; }

        [JsonPropertyName("http-no-cache")]
        public bool HttpNoCache { get; set; }

        [JsonPropertyName("human-readable")]
        public bool HumanReadable { get; set; }

        [JsonPropertyName("keep-unfinished-download-result")]
        public bool KeepUnfinishedDownloadResult { get; set; }

        [JsonPropertyName("listen-port")]
        public string ListenPort { get; set; }

        [JsonPropertyName("log-level")]
        public string LogLevel { get; set; }

        [JsonPropertyName("lowest-speed-limit")]
        public int LowestSpeedLimit { get; set; }

        [JsonPropertyName("max-concurrent-downloads")]
        public int MaxConcurrentDownloads { get; set; }

        [JsonPropertyName("max-connection-per-server")]
        public int MaxConnectionPerServer { get; set; }

        [JsonPropertyName("max-download-limit")]
        public int MaxDownloadLimit { get; set; }

        [JsonPropertyName("max-download-result")]
        public int MaxDownloadResult { get; set; }

        [JsonPropertyName("max-file-not-found")]
        public int MaxFileNotFound { get; set; }

        [JsonPropertyName("max-mmap-limit")]
        public int MaxMmapLimit { get; set; }

        [JsonPropertyName("max-overall-download-limit")]
        public int MaxOverallDownloadLimit { get; set; }

        [JsonPropertyName("max-overall-upload-limit")]
        public int MaxOverallUploadLimit { get; set; }

        [JsonPropertyName("max-resume-failure-tries")]
        public int MaxResumeFailureTries { get; set; }

        [JsonPropertyName("max-tries")]
        public int MaxTries { get; set; }

        [JsonPropertyName("max-upload-limit")]
        public int MaxUploadLimit { get; set; }

        [JsonPropertyName("metalink-enable-unique-protocol")]
        public bool MetalinkEnableUniqueProtocol { get; set; }

        [JsonPropertyName("metalink-preferred-protocol")]
        public string MetalinkPreferredProtocol { get; set; }

        [JsonPropertyName("min-split-size")]
        public int MinSplitSize { get; set; }

        [JsonPropertyName("min-tls-version")]
        public string MinTlsVersion { get; set; }

        [JsonPropertyName("netrc-path")]
        public string NetrcPath { get; set; }

        [JsonPropertyName("no-conf")]
        public bool NoConf { get; set; }

        [JsonPropertyName("no-file-allocation-limit")]
        public int NoFileAllocationLimit { get; set; }

        [JsonPropertyName("no-netrc")]
        public bool NoNetrc { get; set; }

        [JsonPropertyName("optimize-concurrent-downloads")]
        public bool OptimizeConcurrentDownloads { get; set; }

        [JsonPropertyName("parameterized-uri")]
        public bool ParameterizedUri { get; set; }

        [JsonPropertyName("pause-metadata")]
        public bool PauseMetadata { get; set; }

        [JsonPropertyName("peer-agent")]
        public string PeerAgent { get; set; }

        [JsonPropertyName("peer-id-prefix")]
        public string PeerIdPrefix { get; set; }

        [JsonPropertyName("piece-length")]
        public int PieceLength { get; set; }

        [JsonPropertyName("proxy-method")]
        public string ProxyMethod { get; set; }

        [JsonPropertyName("quiet")]
        public bool Quiet { get; set; }

        [JsonPropertyName("realtime-chunk-checksum")]
        public bool RealtimeChunkChecksum { get; set; }

        [JsonPropertyName("remote-time")]
        public bool RemoteTime { get; set; }

        [JsonPropertyName("remove-control-file")]
        public bool RemoveControlFile { get; set; }

        [JsonPropertyName("retry-wait")]
        public int RetryWait { get; set; }

        [JsonPropertyName("reuse-uri")]
        public bool ReuseUri { get; set; }

        [JsonPropertyName("rpc-allow-origin-all")]
        public bool RpcAllowOriginAll { get; set; }

        [JsonPropertyName("rpc-listen-all")]
        public bool RpcListenAll { get; set; }

        [JsonPropertyName("rpc-listen-port")]
        public int RpcListenPort { get; set; }

        [JsonPropertyName("rpc-max-request-size")]
        public int RpcMaxRequestSize { get; set; }

        [JsonPropertyName("rpc-save-upload-metadata")]
        public bool RpcSaveUploadMetadata { get; set; }

        [JsonPropertyName("rpc-secure")]
        public bool RpcSecure { get; set; }

        [JsonPropertyName("save-not-found")]
        public bool SaveNotFound { get; set; }

        [JsonPropertyName("save-session-interval")]
        public int SaveSessionInterval { get; set; }

        [JsonPropertyName("seed-ratio")]
        public string SeedRatio { get; set; }

        [JsonPropertyName("server-stat-timeout")]
        public int ServerStatTimeout { get; set; }

        [JsonPropertyName("show-console-readout")]
        public bool ShowConsoleReadout { get; set; }

        [JsonPropertyName("show-files")]
        public bool ShowFiles { get; set; }

        [JsonPropertyName("socket-recv-buffer-size")]
        public int SocketRecvBufferSize { get; set; }

        [JsonPropertyName("split")]
        public int Split { get; set; }

        [JsonPropertyName("stderr")]
        public bool Stderr { get; set; }

        [JsonPropertyName("stop")]
        public int Stop { get; set; }

        [JsonPropertyName("stream-piece-selector")]
        public string StreamPieceSelector { get; set; }

        [JsonPropertyName("summary-interval")]
        public int SummaryInterval { get; set; }

        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }

        [JsonPropertyName("truncate-console-readout")]
        public bool TruncateConsoleReadout { get; set; }

        [JsonPropertyName("uri-selector")]
        public string UriSelector { get; set; }

        [JsonPropertyName("use-head")]
        public bool UseHead { get; set; }

        [JsonPropertyName("user-agent")]
        public string UserAgent { get; set; }
    }
}
