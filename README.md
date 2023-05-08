# Unity Web Tools
Project with the intention of assisting in the RE of Unity Web applications.

### Current Features
#### Decompress any .unityweb files with Brotli compression:
```bash
UWTool.exe <input_file_path> <output_file_path> # Output File Path is optional.
```

### TODO:
- Unity Web Data
    - [ ] Extract All Assets
- UnityWeb Compressed Content (.unityweb and .wasm)
  - [x] Brotli Decompression
  - [ ] Gzip Decompression
- WebAssembly Binary
  - [ ] Extract 'global-metadata.dat'