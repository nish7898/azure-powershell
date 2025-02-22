---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/invoke-azkeyvaultkeyoperation
schema: 2.0.0
---

# Invoke-AzKeyVaultKeyOperation

## SYNOPSIS
Performs operation like "Encrypt", "Decrypt", "Wrap" or "Unwrap" using a specified key stored in a key vault or managed hsm.

## SYNTAX

### ByVaultName (Default)
```
Invoke-AzKeyVaultKeyOperation [-Version <String>] -Operation <String> -Algorithm <String>
 [-Value <SecureString>] [-ByteArrayValue <Byte[]>] [-Name] <String> [-VaultName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHsmName
```
Invoke-AzKeyVaultKeyOperation [-Version <String>] -Operation <String> -Algorithm <String>
 [-Value <SecureString>] [-ByteArrayValue <Byte[]>] [-HsmName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByKeyInputObject
```
Invoke-AzKeyVaultKeyOperation [-Version <String>] -Operation <String> -Algorithm <String>
 [-Value <SecureString>] [-ByteArrayValue <Byte[]>] [-InputObject] <PSKeyVaultKeyIdentityItem>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Invoke-AzKeyVaultKeyOperation cmdlet supports
1. Encrypting an arbitrary sequence of bytes using an encryption key.
2. Decrypting a single block of encrypted data.
3. Wrapping a symmetric key using a specified key.
4. Unwrapping a symmetric key using the specified key that was initially used for wrapping that key.

## EXAMPLES
### Example 1: Encrypts byte array using an encryption key
```powershell
$byteArray = [Byte[]]@(58, 219)
$encryptedData = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -ByteArrayValue $byteArray
$encryptedData
```

```output
KeyId     : https://bez-kv.vault.azure.net/keys/bez-key/c96ce0fb18de446c9f4b911b686988af
RawResult : {21, 39, 82, 56…}
Algorithm : RSA1_5
```

Encrypts `$byteArray` using test-key stored in test-kv.

### Example 2: Decrypts byte array using an encryption key
```powershell
$decryptedData = Invoke-AzKeyVaultKeyOperation -Operation Decrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -ByteArrayValue $encryptedData.RawResult
$decryptedData
```

```output
KeyId     : https://bez-kv.vault.azure.net/keys/bez-key/c96ce0fb18de446c9f4b911b686988af
RawResult : {58, 219}
Algorithm : RSA1_5
```

Decrypts `$encryptedData.RawResult` using test-key stored in test-kv. The `$decryptedData.RawResult` is same with `$byteArray`, which is original data.

### Example 3: Encrypts plain text using an encryption key
```powershell
$encryptedData = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force)
$encryptedData
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/bd8b77352a2443d4983bd70e9f660bc6
RawResult : {58, 219, 6, 236…}
Algorithm : RSA1_5
```

Encrypts string "test" using test-key stored in test-kv. The `RawResult` is the encrypted result in byte array format, where [System.Convert]::ToBase64String($encryptedData.RawResult) equals $encryptedData.Result.

### Example 4: Decrypt encrypted data to plain text
```powershell
$decryptedData = Invoke-AzKeyVaultKeyOperation -Operation Decrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -ByteArrayValue $encryptedData.RawResult
$decryptedData
```

```output
KeyId     : https://bez-kv.vault.azure.net/keys/bez-key/c96ce0fb18de446c9f4b911b686988af
RawResult : $byteArray
Algorithm : RSA1_5
```

Decrypts encrypted data that is encrypted using test-key stored in test-kv. The `$decryptedData.Result` is `test`. The `RawResult` is the decrypted result in byte array format, where [System.Text.UTF8Encoding]::UTF8.GetString($decryptedData.RawResult) equals $decryptedData.Result.

### Example 5: Wraps a symmetric key using a specified key
```powershell
$wrappedResult = Invoke-AzKeyVaultKeyOperation -Operation Wrap -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "ovQIlbB0DgWhZA7sgkPxbg9H-Ly-VlNGPSgGrrZvlIo" -AsPlainText -Force) 

$wrappedResult | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
RawResult : {58, 219, 6, 236…}
Algorithm : RSA1_5
```

Wraps a symmetric key using key named test-key stored in test-kv. The `Result` is wrapped result in Base64 string format.

### Example 6: Unwraps a symmetric key using a specified key
```powershell
Invoke-AzKeyVaultKeyOperation -Operation Unwrap -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String $result.Result -AsPlainText -Force)
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
RawResult : {58, 219, 6, 236…}
Algorithm : RSA1_5
```

Unwraps a symmetric key using a specified key test-key stored in test-kv. The `Result` is a plain string.

## PARAMETERS

### -Algorithm
Algorithm identifier

```yaml
Type: String
Parameter Sets: (All)
Aliases: EncryptionAlgorithm, WrapAlgorithm

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ByteArrayValue
The value to be operated in byte array format.

```yaml
Type: Byte[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
HSM name.

```yaml
Type: String
Parameter Sets: ByHsmName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Key object

```yaml
Type: PSKeyVaultKeyIdentityItem
Parameter Sets: ByKeyInputObject
Aliases: Key

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Key name.

```yaml
Type: String
Parameter Sets: ByVaultName, ByHsmName
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
Algorithm identifier

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The value to be operated. This parameter will be converted to byte array in UTF-8 encoding way. If your value can't be encoded by UTF-8, please use parameter ByteArrayValue as its alternative.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Vault name.

```yaml
Type: String
Parameter Sets: ByVaultName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Key version.

```yaml
Type: String
Parameter Sets: (All)
Aliases: KeyVersion

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyOperationResult

## NOTES

## RELATED LINKS
